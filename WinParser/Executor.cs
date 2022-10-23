using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using WinParser.Data;
using WinParser.Tools;

namespace WinParser
{
    public static class Executor
    {

        private static MySqlConnection _conn = DB.GetParam();

        private static List<User> _users = new List<User>();
        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User Login(string login, string password)
        {
            int userID = -1;
            int sheetCount = 0;
            try
            {
                //_conn = DB.GetParam();
                MySqlCommand script = new MySqlCommand();
                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                _conn.Open();
                script.Connection = _conn;
                script.CommandText = string.Format(@"SELECT Users.*, score_money.money 
                                                        FROM Users 
                                                        INNER JOIN score_money ON score_money.id_user = Users.ID
                                                        WHERE Users.login = @Login AND Users.password = @Password");
                script.Parameters.Add(new MySqlParameter("@Login", login));
                script.Parameters.Add(new MySqlParameter("@Password", password));
                using (MySqlDataReader reader = script.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["ID"].ToString(), out userID);
                        int.TryParse(reader["money"].ToString(), out sheetCount);
                    }
                }
                User sUser = new User() { ID = userID, Login = login, SheetCount = sheetCount };
                _users.Add(sUser);

                return sUser;
            }
            finally 
            {
                _conn.Close();
                //_conn = DB.GetParam();
            }
        }

        /// <summary>
        /// Отключение
        /// </summary>
        /// <param name="userID"></param>
        public static void Disconnect(int userID)
        {
            User user = _users.Find(i => i.ID == userID);
            if (user != null)
                _users.Remove(user);
        }
        /// <summary>
        /// Получить ключ
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static string Get_Key(out string error)
        {
            error = string.Empty;

            try
            {
                MySqlCommand script = new MySqlCommand();
                _conn.Open();
                script.Connection = _conn;
                string key = string.Empty;
                script.CommandText = string.Format(@"SELECT key_value FROM use_keys WHERE 
            (((SELECT CURRENT_TIME() FROM DUAL) - time)/100) > 5 OR time is null
             LIMIT 1");

                using (MySqlDataReader reader = script.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader["key_value"].ToString();
                    }
                }
            }
            catch (Exception ex) { error = ex.Message; }
            finally { _conn.Close(); }

            return null;
        }
        /// <summary>
        /// Обновляем дату ключа
        /// </summary>
        /// <param name="currentKey"></param>
        /// <param name="error"></param>
        public static void Update_Key(string currentKey, out string error)
        {
            error = string.Empty;

            try
            {
                MySqlCommand script = new MySqlCommand();
                _conn.Open();
                script.Connection = _conn;
                
                script.CommandText = string.Format(@"UPDATE use_keys 
                SET time=(SELECT CURRENT_TIME() FROM DUAL) WHERE key_value =@Key");

                script.Parameters.Add(new MySqlParameter("@id_user", currentKey));
                script.ExecuteNonQuery();
            }
            catch (Exception ex) { error = ex.Message; }
            finally { _conn.Close(); }
        }

        public static List<Order> Get_Orders(int userID,  out string error)
        {
            error = string.Empty;

            try
            {
                MySqlCommand script = new MySqlCommand();
                List<Order> list = new List<Order>();
                _conn.Open();
                script.Connection = _conn;
                script.CommandText = string.Format(@"SELECT info_orders.*, orders.status
                                            FROM info_orders
                                            INNER JOIN orders ON orders.id_order = info_orders.id
                                            WHERE 	id_user=@id_user");

                script.Parameters.Add(new MySqlParameter("@id_user", userID));
                using (MySqlDataReader reader = script.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order()
                        {
                            Number = reader["Number"].ToString()
                        };
                        list.Add(order);
                    }
                }

                return list;
            }
            catch (Exception ex) { error = ex.Message; }
            finally { _conn.Close(); }

            return null;
        }
        public static void Add_Order(int userID, Order order, out string error)
        {
            error = string.Empty;

            try
            {
                MySqlCommand script = new MySqlCommand();
                List<Order> list = new List<Order>();
                _conn.Open();
                script.Connection = _conn;
                script.CommandText = string.Format(@"INSERT INTO info_orders 
                (`number`, `date_create`, `download_link`, `cadastral_number`, `full_adderess`,
                 `type_object`, `square`, `category_zu`, `type_zu`, `purpose`) 
                VALUES (@number, @date_create, @download_link, @cadastral_number, @full_adderess,
                 @type_object, @square, @category_zu, @type_zu, @purpose)

                SELECT LAST_INSERT_ID() AS NewID  ");
                
                script.Parameters.Add(new MySqlParameter("@number", order.Number));
                script.Parameters.Add(new MySqlParameter("@date_create", order.DateCreate));
                script.Parameters.Add(new MySqlParameter("@download_link", order.Link));
                script.Parameters.Add(new MySqlParameter("@cadastral_number", order.CadastralNumber));
                script.Parameters.Add(new MySqlParameter("@full_adderess", order.FullAdderess));
                script.Parameters.Add(new MySqlParameter("@type_object", order.TypeObject));
                script.Parameters.Add(new MySqlParameter("@square", order.Square));
                script.Parameters.Add(new MySqlParameter("@category_zu", order.CategoryZU));
                script.Parameters.Add(new MySqlParameter("@type_zu", order.TypeZU));
                script.Parameters.Add(new MySqlParameter("@purpose", order.Purpose));
                using (MySqlDataReader reader = script.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["NewID"].ToString(), out int id);
                        order.ID = id;
                    }
                }

                script.CommandText = string.Format(@"INSERT INTO orders 
                                                (`id_order`, `id_user`, `status`) 
                                                VALUES (@id_order, @id_user, @status)");
                script.Parameters.Add(new MySqlParameter("@id_order", order.ID));
                script.Parameters.Add(new MySqlParameter("@id_user", userID));
                script.Parameters.Add(new MySqlParameter("@status", order.State));
                script.ExecuteNonQuery();

            }
            catch (Exception ex) { error = ex.Message; }
            finally { _conn.Close(); }
        }
        public static void Update_Order(int userID, Order order, out string error)
        {
            error = string.Empty;

            try
            {
                MySqlCommand script = new MySqlCommand();
                List<Order> list = new List<Order>();
                _conn.Open();
                script.Connection = _conn;
                string command = "UPDATE info_orders ";
                string subCommand = "";
                if (!string.IsNullOrEmpty(order.Number))
                {
                    if (!string.IsNullOrEmpty(subCommand))
                        subCommand += ", number = @number";
                    else
                        subCommand = "number = @Number";

                    script.Parameters.Add(new MySqlParameter("@number", order.Number));
                }
                if (order.DateCreate != null)
                {
                    if (!string.IsNullOrEmpty(subCommand))
                        subCommand += ", date_create = @date_create";
                    else
                        subCommand = "date_create = @date_create";

                    script.Parameters.Add(new MySqlParameter("@date_create", order.DateCreate));
                }
                if (!string.IsNullOrEmpty(order.Link))
                {
                    if (!string.IsNullOrEmpty(subCommand))
                        subCommand += ", download_link = @download_link";
                    else
                        subCommand = "download_link = @download_link";

                    script.Parameters.Add(new MySqlParameter("@download_link", order.Link));
                }
                if (!string.IsNullOrEmpty(order.CadastralNumber))
                {
                    if (!string.IsNullOrEmpty(subCommand))
                        subCommand += ", cadastral_number = @cadastral_number";
                    else
                        subCommand = "cadastral_number = @cadastral_number";

                    script.Parameters.Add(new MySqlParameter("@cadastral_number", order.CadastralNumber));
                }
                if (!string.IsNullOrEmpty(order.FullAdderess))
                {
                    if (!string.IsNullOrEmpty(subCommand))
                        subCommand += ", full_adderess = @full_adderess";
                    else
                        subCommand = "full_adderess = @full_adderess";

                    script.Parameters.Add(new MySqlParameter("@full_adderess", order.FullAdderess));
                }
                if (!string.IsNullOrEmpty(order.TypeObject))
                {
                    if (!string.IsNullOrEmpty(subCommand))
                        subCommand += ", type_object = @type_object";
                    else
                        subCommand = "type_object = @type_object";

                    script.Parameters.Add(new MySqlParameter("@type_object", order.TypeObject));
                }
                if (!string.IsNullOrEmpty(order.Square))
                {
                    if (!string.IsNullOrEmpty(subCommand))
                        subCommand += ", square = @square";
                    else
                        subCommand = "square = @square";

                    script.Parameters.Add(new MySqlParameter("@square", order.Square));
                }
                if (!string.IsNullOrEmpty(order.CategoryZU))
                {
                    if (!string.IsNullOrEmpty(subCommand))
                        subCommand += ", category_zu = @category_zu";
                    else
                        subCommand = "category_zu = @category_zu";

                    script.Parameters.Add(new MySqlParameter("@category_zu", order.CategoryZU));
                }
                if (!string.IsNullOrEmpty(order.TypeZU))
                {
                    if (!string.IsNullOrEmpty(subCommand))
                        subCommand += ", type_zu = @type_zu";
                    else
                        subCommand = "type_zu = @type_zu";

                    script.Parameters.Add(new MySqlParameter("@type_zu", order.TypeZU));
                }
                if (!string.IsNullOrEmpty(order.Purpose))
                {
                    if (!string.IsNullOrEmpty(subCommand))
                        subCommand += ", purpose = @purpose";
                    else
                        subCommand = "purpose = @purpose";

                    script.Parameters.Add(new MySqlParameter("@purpose", order.Purpose));
                }
                script.CommandText = string.Format(@"UPDATE info_orders 
                (`number`, `date_create`, `download_link`, `cadastral_number`, `full_adderess`,
                 `type_object`, `square`, `category_zu`, `type_zu`, `purpose`) 
                VALUES (@number, @date_create, @download_link, @cadastral_number, @full_adderess,
                 @type_object, @square, @category_zu, @type_zu, @purpose)

                SELECT LAST_INSERT_ID() AS NewID  ");

                using (MySqlDataReader reader = script.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["NewID"].ToString(), out int id);
                        order.ID = id;
                    }
                }

                script.CommandText = string.Format(@"INSERT INTO orders 
                                                (`id_order`, `id_user`, `status`) 
                                                VALUES (@id_order, @id_user, @status)");
                script.Parameters.Add(new MySqlParameter("@id_order", order.ID));
                script.Parameters.Add(new MySqlParameter("@id_user", userID));
                script.Parameters.Add(new MySqlParameter("@status", order.State));
                script.ExecuteNonQuery();

            }
            catch (Exception ex) { error = ex.Message; }
            finally { _conn.Close(); }
        }

        public static void Action_Orders(int userID, List<Order> orders, out string error) 
        {
            error = string.Empty;
            foreach (Order order in orders) 
            {
                if (order.ID <= 0)
                    Add_Order(userID, order, out error);
                else
                    Update_Order(userID, order, out error);
            }
        }

        public static void Add_Orders(int userID, List<Order> orders, out string error)
        {
            error = string.Empty;
            foreach (Order order in orders)
            {
                if (order.ID <= 0)
                    Add_Order(userID, order, out error);
            }
        }
    }
}

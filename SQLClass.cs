using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media.Imaging;
using System.Data.Common;
using Npgsql;

namespace InstaMilligram
{
    public static class SQLClass
    {
        public static NpgsqlConnection conn;

        public static void OpenConnection()
        {
            conn = new NpgsqlConnection
            {
                ConnectionString =
                    "Host=localhost;Username=postgres;Password=postgres;Database=Insta"
            };
            conn.Open();
        }

        public static void CloseConnection()
        {
            conn.Close();
        }
        public static void Insert(String Text)
        {
            NpgsqlCommand command = new NpgsqlCommand(Text, conn);
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public static void UpdateImg(String Text, String address)
        {
            using FileStream pgFileStream = new FileStream(address, FileMode.Open, FileAccess.Read);
            using BinaryReader pgReader = new BinaryReader(new BufferedStream(pgFileStream));
            using NpgsqlCommand command = new NpgsqlCommand(Text, conn);

            byte[] ImgByteA = pgReader.ReadBytes(Convert.ToInt32(pgFileStream.Length));

            NpgsqlParameter param = command.CreateParameter();
            param.ParameterName = "@Image";
            param.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bytea;
            param.Value = ImgByteA;
            command.Parameters.Add(param);

            command.ExecuteNonQuery();
        }

        public static BitmapImage SelectImage(String Text)
        {
            BitmapImage image = new BitmapImage();
            using NpgsqlCommand command = new NpgsqlCommand(Text, conn);
            using NpgsqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    //Предполагается, что в запросе 1 столбец, и в нем картинка
                    byte[] data = (byte[])reader.GetValue(0);
                    try
                    {
                        image.BeginInit();
                        image.StreamSource = new MemoryStream(data);
                        image.EndInit();
                    }
                    catch { }
                }
            }
            catch (Exception) { }

            return image;
        }


        public static List<string> Select(String Text)
        {
            List<string> results = new List<string>();
            NpgsqlCommand command = new NpgsqlCommand(Text, conn);

            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    results.Add(reader.GetValue(i).ToString());
            }
            reader.Close();
            command.Dispose();

            return results;
        }
    }
}


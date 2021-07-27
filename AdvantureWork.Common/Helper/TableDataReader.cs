using System;
using System.Data;

namespace AdvantureWork.Common.Helper
{
    internal class TableDataReader : BaseClass
    {
        private DateTime defaultDate;

        public TableDataReader(DataTable table, int rowIndex)
        {
            this.defaultDate = DateTime.MinValue;
            this.table = table;
            this.currentRow = table.Rows[rowIndex];
        }

        public int GetInt32(String column)
        {
            int data = 0;

            if (DoesFieldExists(table, column))
            {
                data = (currentRow[column] == null) ? 0 : (int)currentRow[column];
            }

            return data;
        }

        public long GetLong(String column)
        {
            long data = 0;

            if (DoesFieldExists(table, column))
            {
                data = (currentRow[column] == null) ? 0 : (long)currentRow[column];
            }

            return data;
        }

        public short GetInt16(String column)
        {
            short data = 0;
            object value = 0;

            if (DoesFieldExists(table, column))
            {
                value = (currentRow[column] == null) ? 0 : (short)currentRow[column];
            }
            data = (short)value;

            return data;
        }

        public float GetFloat(String column)
        {
            float data = 0;

            if (DoesFieldExists(table, column))
            {
                data = (currentRow[column] == null) ? 0 : (float)currentRow[column];
            }

            return data;
        }

        public decimal GetDecimal(String column)
        {
            decimal data = 0;

            if (DoesFieldExists(table, column))
            {
                data = (currentRow[column] == null) ? 0 : (decimal)currentRow[column];
            }

            return data;
        }

        public bool GetBoolean(String column)
        {
            bool data = false;

            if (DoesFieldExists(table, column))
            {
                data = (currentRow[column] == null) ? false : (bool)currentRow[column];
            }

            return data;
        }

        public string GetString(String column)
        {
            string data = string.Empty;

            if (DoesFieldExists(table, column))
            {
                data = Convert.ToString(currentRow[column]);
            }

            return data;
        }

        public DateTime GetDateTime(String column)
        {
            DateTime data = defaultDate;

            if (DoesFieldExists(table, column))
            {
                data = (currentRow[column] == null) ? defaultDate : (DateTime)currentRow[column];
            }

            return data;
        }

        private bool DoesFieldExists(DataTable reader, string fieldName)
        {
            if (reader.Columns.Contains(fieldName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private DataTable table;
        private DataRow currentRow;
    }
}
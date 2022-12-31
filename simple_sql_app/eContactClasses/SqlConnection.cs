namespace simple_sql_app.eContactClasses
{
    internal class SqlConnection
    {
        private string myconnstrng;

        public SqlConnection(string myconnstrng)
        {
            this.myconnstrng = myconnstrng;
        }
    }
}
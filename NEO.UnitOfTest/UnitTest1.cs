using System;
using System.Data;
using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using NEO.Core;

namespace NEO.UnitOfTest
{
    [TestClass]
    public class UnitTest1
    {
        private IDbConnection conn = new MySqlConnection("Server=localhost;Database=neos;Uid=root;Pwd=123456;");

        [TestMethod]
        public void TestMethod1()
        {
            CommandDefinition definition = new CommandDefinition();
        }
    }
}

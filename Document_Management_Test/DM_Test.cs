using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Document_Management_Test
{
    [TestFixture]
    public class DM_Test
    {
        private Document_Management.Login login;
        private Document_Management.Doc_Management docmng;
        private Document_Management.User_Management usermng;

        [SetUp]
        public void SetUp()
        {
            login = new Document_Management.Login();
            docmng = new Document_Management.Doc_Management();
            usermng = new Document_Management.User_Management();
        }

        //Login test cases
        [Test]
        public void LoginTest1()
        {
            Assert.AreEqual("", login.getID("admin", ""));
        }

        [Test]
        public void LoginTest2()
        {
            Assert.AreEqual("1", login.getID("admin", "1234"));
        }

        [Test]
        public void LoginTest3()
        {
            Assert.AreEqual("2", login.getID("director", "0123"));
        }

        [Test]
        public void LoginTest4()
        {
            Assert.AreEqual("", login.getID("", "0123"));
        }

        [Test]
        public void LoginTest5()
        {
            Assert.AreEqual("", login.getID("worker", ""));
        }
        //Create Document Testcases
        [Test]
        public void AddDocTest1()
        {
            Assert.AreEqual(0, docmng.CheckAdd("", "Thông báo", "Thông báo về việc tổ chức thi cuối kỳ", "Trường ĐH CNTT", "Lâm"));
        }

        [Test]
        public void AddDocTest2()
        {
            Assert.AreEqual(-2, docmng.CheckAdd("-3", "Hướng dẫn", "Hướng dẫn báo cáo cuối kỳ", "UBND TP Thủ Đức", "Lâm"));
        }

        [Test]
        public void AddDocTest3()
        {
            Assert.AreEqual(0, docmng.CheckAdd("1", "Thông báo", "", "UBND TP Thủ Đức", "Lâm"));
        }

        [Test]
        public void AddDocTest4()
        {
            Assert.AreEqual(1, docmng.CheckAdd("5", "Hướng dẫn", "Hướng dẫn báo cáo cuối kỳ", "UBND TP Thủ Đức", "Lâm"));
        }

        [Test]
        public void AddDocTest5()
        {
            Assert.AreEqual(1, docmng.CheckAdd("1", "Thông báo", "Hướng dẫn báo cáo cuối kỳ", "Trường ĐH CNTT", "Lâm"));
        }

        //Update Document Testcases
        [Test]
        public void UpdateDocTest1()
        {
            Assert.AreEqual(0, docmng.CheckUpdate("", "Báo cáo", "Báo cáo cuối kỳ", "Trường ĐH CNTT", "Lâm"));
        }

        [Test]
        public void UpdateDocTest2()
        {
            Assert.AreEqual(-1, docmng.CheckUpdate("-3", "", "Báo cáo cuối kỳ", "", "Lâm"));
        }

        [Test]
        public void UpdateDocTest3()
        {
            Assert.AreEqual(-1, docmng.CheckUpdate("1", "Báo cáo", "Báo cáo cuối kỳ", "", ""));
        }

        [Test]
        public void UpdateDocTest4()
        {
            Assert.AreEqual(-1, docmng.CheckUpdate("1", "Báo cáo", "", "Trường ĐH CNTT", "Lâm"));
        }

        [Test]
        public void UpdateDocTest5()
        {
            Assert.AreEqual(1, docmng.CheckUpdate("2", "Báo cáo", "Báo cáo cuối kỳ", "Trường ĐH CNTT", "Lâm"));
        }
        //Delete Document Testcases
        [Test]
        public void DeleteDocTest1()
        {
            Assert.AreEqual(-1, docmng.CheckDelete("1"));
        }

        [Test]
        public void DeleteDocTest2()
        {
            Assert.AreEqual(0, docmng.CheckDelete(""));
        }

        [Test]
        public void DeleteDocTest3()
        {
            Assert.AreEqual(-1, docmng.CheckDelete("23"));
        }

        //Create User Testcases
        [Test]
        public void AddUserTest1()
        {
            Assert.AreEqual(0, usermng.CheckAdd("", "", "", "Nhân viên"));
        }

        [Test]
        public void AddUserTest2()
        {
            Assert.AreEqual(2, usermng.CheckAdd("7", "21w44a", "Nhân viên", ""));
        }

        [Test]
        public void AddUserTest3()
        {
            Assert.AreEqual(2, usermng.CheckAdd("2", "worker", "Nhân viên", ""));
        }

        [Test]
        public void AddUserTest4()
        {
            Assert.AreEqual(1, usermng.CheckAdd("21", "adnim", "Trưởng phòng", "password"));
        }

        [Test]
        public void AddUserTest5()
        {
            Assert.AreEqual(1, usermng.CheckAdd("13", "workertoo", "Nhân viên", "password"));
        }

        //Update User Testcases
        [Test]
        public void UpdateUserTest1()
        {
            Assert.AreEqual(0, usermng.CheckUpdate("", "", "", ""));
        }

        [Test]
        public void UpdateUserTest2()
        {
            Assert.AreEqual(0, usermng.CheckUpdate("-2", "adminthree", "", "Trưởng phòng"));
        }

        [Test]
        public void UpdateUserTest3()
        {
            Assert.AreEqual(0, usermng.CheckUpdate("1", "", "012346789", ""));
        }

        [Test]
        public void UpdateUserTest4()
        {
            Assert.AreEqual(1, usermng.CheckUpdate("1", "userr", "0123456789", "Nhân viên"));
        }

        [Test]
        public void UpdateUserTest5()
        {
            Assert.AreEqual(1, usermng.CheckUpdate("1", "adminthree", "0123456789", "Trưởng phòng"));
        }
        //Delete Document Testcases
        [Test]
        public void DeleteUserTest1()
        {
            Assert.AreEqual(-1, usermng.CheckDelete(1, 4));
        }

        [Test]
        public void DeleteUserTest2()
        {
            Assert.AreEqual(-1, usermng.CheckDelete(19, 4));
        }

        [Test]
        public void DeleteUserTest3()
        {
            Assert.AreEqual(-1, usermng.CheckDelete(7, 4));
        }
    }
}

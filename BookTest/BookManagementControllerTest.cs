using bookDao;
using bookModel;
using bookService;
using Course4_Net_MVC.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Spring.Testing.Microsoft;
using System;
using System.Web.Mvc;

namespace BookTest
{
    [TestClass]
    public class BookManagementControllerTest : AbstractDependencyInjectionSpringContextTests
    {
       
        protected override string[] ConfigLocations => new String[] { "C:\\Users\\kayden_tsai\\Desktop\\Kayden\\GitLab\\course6\\Section1\\Course6_BackEnd\\BookTest\\spring-config\\objects.xml" };

        private IBookService bookService { get; set; }

        [TestMethod]
        public void DestroyTest()
        {
            // Arrange
            //IBookDao bookDao = new BookDao();
            //IBookService bookService = new BookService();
            //var controller = new BookManagementController(bookService);



            // Act
            //var result = controller.Destroy(1);

            Assert.IsNotNull(bookService.GetBookDao());
            // Assert
            //Assert.IsNotNull(result);
            //Assert.AreEqual("刪除成功！",);
        }
    }
}

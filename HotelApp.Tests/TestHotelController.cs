using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelApp.Models;
using HotelApp.Controllers;
using System.Web.Http.Results;
using System.Threading.Tasks;

namespace HotelApp.Tests
{
    /// <summary>
    /// Summary description for TestHotelController
    /// </summary>
    [TestClass]
    public class TestHotelController
    {
        private List<Hotel> hotels;
        private HotelController controller;

        public TestHotelController()
        {
            //
            // TODO: Add constructor logic here
            //
            hotels = new List<Hotel>();

            hotels.Add(new Hotel { ID = 1, Name = "Hotel Canapay", TotalRooms = 15 });
            hotels.Add(new Hotel { ID = 2, Name = "Grand Hotel", TotalRooms = 200 });
            hotels.Add(new Hotel { ID = 3, Name = "March Motel", TotalRooms = 10 });
            hotels.Add(new Hotel { ID = 4, Name = "Hotel Amica", TotalRooms = 50 });

            controller = new HotelController(hotels);
        }

        [TestMethod]
        public void GetAllProducts_ReturnsAllProducts()
        {
            var hotels = controller.getAllHotels() as List<Hotel>;
            Assert.AreEqual(hotels, this.hotels);
        }

        [TestMethod]
        public async Task GetAllHotelsAsync_ReturnsAllHotels()
        {
            var hotels = await controller.getAllHotelsAsync() as List<Hotel>;
            Assert.AreEqual(hotels, this.hotels);
        }

        [TestMethod]
        public void GetHotel_ReturnsHotel()
        {
            var hotel = controller.getHotel(2) as OkNegotiatedContentResult<Hotel>;
            Assert.IsNotNull(hotel);
            Assert.AreEqual(hotel.Content.ID, this.hotels[1].ID);
        }

        [TestMethod]
        public async Task GetHotelAsync_ReturnsHotel()
        {
            var hotel = await controller.getHotelAsync(2) as OkNegotiatedContentResult<Hotel>;
            Assert.IsNotNull(hotel);
            Assert.AreEqual(hotel.Content.ID, this.hotels[1].ID);
        }

        [TestMethod]
        public void GetHotel_ReturnsNotFound()
        {
            var hotel = controller.getHotel(-1);
            Assert.IsInstanceOfType(hotel, typeof(NotFoundResult));
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
            
    }
}

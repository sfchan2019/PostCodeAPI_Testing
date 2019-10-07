using System;
using NUnit.Framework;
using PostCodeESIO;
using System.Configuration;


namespace PostCodeESIO.Test
{
    [TestFixture]
    public class PostCodeESIOTest
    {
        SinglePostCode singlePostCode = new SinglePostCode();
        //public void SinglePostCodeServiceTests()
        //{

            
        //}

        [Test]
        public void Status200()
        {
            //string postcode = "EC2y 5AS";
            //singlePostCode.GetSinglePostcode(postcode);
            //Assert.AreEqual("200", singlePostCode.PostCodeSingleResponseContent["status"].ToString());
            Assert.AreEqual(0, singlePostCode.base_uri);
        }
    }
}

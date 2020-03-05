using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logicalmind.Cryption.Test
{
    [TestClass]
    public class FunctionalTests
    {
        [TestMethod]
        public void EncryptDecryptTest()
        {
            var key = "MyKey";
            var unencrypted = "Some Test String";

            var c = new Cryptor(key);

            var encrypted = c.Encrypt(unencrypted);

            var decrypted = c.Decrypt(encrypted);

            Assert.AreEqual(unencrypted, decrypted);

        }
    }
}

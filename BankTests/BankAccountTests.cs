using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Orgnaizar;
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // agir;
            account.Debit(debitAmount);

            // Afirmar;
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }
        [TestMethod]
        public void Debit_WhenAmountIsMoreThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [TestMethod]
        public void Credit_WhenTheAmountItsLessEqualOrThanZero_ShouldThrowsArgumentOutOfRange()
        {
            //Arrange
            double balanceInitial = 10000.00;
            double creditAmount = -80000.00;
            BankAccount bill = new BankAccount("Mr. Samuel Lopes", balanceInitial);

            //Act and Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => bill.Credit(creditAmount));
        }

        [TestMethod]
        public void Credit_WhenTheAmountItsEqualOrMuchThanActual_ShouldThrowsArgumentOutRange()
        {
            //Arrange
            double balanceInitial = 200.00;
            double creditAmount = 53.6;
            double hoped = 253.6;
            BankAccount bill = new BankAccount("Mr. Samuel Lopes", balanceInitial);

            //Act
            bill.Credit(creditAmount);

            //Assert
            double actual = bill.Balance;
            Assert.AreEqual(hoped, actual, 0.001, "Bill not credited correctly");
        }
    }
}

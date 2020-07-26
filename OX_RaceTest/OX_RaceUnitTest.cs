using OX_Race;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OX_RaceTest
{
    [TestClass]
    public class OX_RaceUnitTest
    {
        PlayerFactory objFactory = new PlayerFactory();
        Punter Amr;
        OX[] OXs = new OX[2];

        [TestMethod]
        public void TestWinnerOutcome()
        {
            OX.StartingPosition1 = 0;
            OX.RacetrackLength1 = 50;
            int BettingAmount = 50;
            int OXNumber = 1;
            int expectedWin = 100;
            int expectedLose = 0;
            OXs[0] = new OX() { OXPictureBox = null };
            OXs[1] = new OX() { OXPictureBox = null };
            Amr = objFactory.getPunter("Amr", null, null);
            Amr.money = BettingAmount;
            Amr.PlaceBet((int)BettingAmount, OXNumber);

            bool nowin = true;
            int win = -1;
            while (nowin)
            {
                for (int i = 0; i < OXs.Length; i++)
                {
                    if (OX.Run(OXs[i]))
                    {
                        win = i + 1;
                        Amr.Collect(win);
                        nowin = false;

                    }
                }
            }
            if (Amr.gamble.OXNum == win)
            {
                Assert.AreEqual(expectedWin, Amr.money, "Account not credited correctly");
            }
            if (Amr.gamble.OXNum != win)
            {
                Assert.AreEqual(expectedLose, Amr.money, "Account not debited correctly");

            }
        }
    }

}

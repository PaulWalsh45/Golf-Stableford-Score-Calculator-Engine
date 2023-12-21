using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScoreCalcEngine.Tests
{
    [TestClass]
    public class ScoreTests
    {
        protected readonly ICalculation Calculation;

        public ScoreTests()
        {
            this.Calculation = new CalcService();
        }

        [TestMethod]
        public async Task GetRoundScore_Handicap_18()
        {
            //// Arrange
            List<Int32> scores = new List<Int32>() { 5, 5, 5, 5, 5, 6, 6, 4, 4, 5, 5, 5, 5, 5, 6, 6, 4, 4 };
            List<Int32> pars = new List<Int32>() { 4, 4, 4, 4, 4, 5, 5, 3, 3, 4, 4, 4, 4, 4, 5, 5, 3, 3 };
            List<Int32> indices = new List<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
            Int32 handicap = 18;

            //// Act
            Int32 total = await this.Calculation.GetRoundStableford(indices,pars,scores, handicap); 

            //// Assert
            Assert.AreEqual(36,total,"Total Stableford Score");
        }

        [TestMethod]
        public async Task GetRoundScore_Handicap_18_WithScratches()
        {
            //// Arrange
            List<Int32> scores = new List<Int32>() { 0, 5, 5, 5, 0, 6, 6, 4, 4, 5, 5, 0, 5, 5, 6, 0, 4, 4 };
            List<Int32> pars = new List<Int32>() { 4, 4, 4, 4, 4, 5, 5, 3, 3, 4, 4, 4, 4, 4, 5, 5, 3, 3 };
            List<Int32> indices = new List<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
            Int32 handicap = 18;

            //// Act
            Int32 total = await this.Calculation.GetRoundStableford(indices, pars, scores, handicap);

            //// Assert
            Assert.AreEqual(28, total, "Total Stableford Score");
        }

        [TestMethod]
        public async Task GetRoundScore_Handicap_10()
        {
            //// Arrange
            List<Int32> scores = new List<Int32>() { 5, 5, 5, 5, 5, 6, 6, 4, 4, 5, 5, 5, 5, 5, 6, 6, 4, 4 };
            List<Int32> pars = new List<Int32>() { 4, 4, 4, 4, 4, 5, 5, 3, 3, 4, 4, 4, 4, 4, 5, 5, 3, 3 };
            List<Int32> indices = new List<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
            Int32 handicap = 10;

            //// Act
            Int32 total = await this.Calculation.GetRoundStableford(indices, pars, scores, handicap);

            //// Assert
            Assert.AreEqual(28, total, "Total Stableford Score");
        }

        [TestMethod]
        public async Task GetRoundScore_Handicap_28()
        {
            //// Arrange
            List<Int32> scores = new List<Int32>()  { 5, 5, 5, 5, 5, 6, 6, 4, 4, 5, 5, 5, 5, 5, 6, 6, 4, 4 };
            List<Int32> pars = new List<Int32>()    { 4, 4, 4, 4, 4, 5, 5, 3, 3, 4, 4, 4, 4, 4, 5, 5, 3, 3 };
            List<Int32> indices = new List<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
            Int32 handicap = 28;

            //// Act
            Int32 total = await this.Calculation.GetRoundStableford(indices, pars, scores, handicap);

            //// Assert
            Assert.AreEqual(46, total, "Total Stableford Score");
        }

        [TestMethod]
        public async Task GetHoleScore_Handicap_18()
        {
            //// Arrange
            Int32 score = 5;
            Int32 par = 4;
            Int32 index = 1;

            //// Act
            Int32 total = await this.Calculation.GetHoleStableford(index, par, score, 28);

            //// Assert
            Assert.AreEqual(3, total, "Total Stableford Score");
        }

        [TestMethod]
        public async Task GetHoleScore_Handicap_10()
        {
            //// Arrange
            Int32 score = 4;
            Int32 par = 4;
            Int32 index = 11;
            Int32 handicap = 10;

            //// Act
            Int32 total = await this.Calculation.GetHoleStableford(index, par, score, handicap);

            //// Assert
            Assert.AreEqual(2, total, "Total Stableford Score");
        }

        [TestMethod]
        public async Task GetHoleScore_Scratch()
        {
            //// Arrange
            Int32 score = 0;
            Int32 par = 4;
            Int32 index = 11;
            Int32 handicap = 10;

            //// Act
            Int32 total = await this.Calculation.GetHoleStableford(index, par, score, handicap);

            //// Assert
            Assert.AreEqual(0, total, "Total Stableford Score");
        }
    }
}
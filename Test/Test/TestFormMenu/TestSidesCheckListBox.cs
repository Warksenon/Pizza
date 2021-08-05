using System.Collections.Generic;
using System.Windows.Forms;
using NUnit.Framework;

using Pizza.Presenters.PresenterFormMenu;

namespace Test.Test.TestFormMenu
{
    [TestFixture]
    public class TestSidesCheckListBox
    {
        [TestCase( "0", "pieczarki" )]
        [TestCase( "1", "salami" )]
        [TestCase( "2", "szynka" )]
        [TestCase( "3", "podwójny ser" )]
        public void SetList_CheckSetList_StringName ( int index, string expecteName )
        {
            var form = FormTest.CreateFormMenu();
            var sidesChLBox = new  SidesCheckListBox(form);
            var listSides = FakeCreateFourSides.GetList();
            sidesChLBox.SetList( listSides );

            var currentSides = form.CheckedListBoxSide.Items[index].ToString();

            Assert.AreEqual( expecteName, currentSides );
        }

        [TestCase( "0", "pieczarki" )]
        [TestCase( "1", "salami" )]
        [TestCase( "2", "szynka" )]
        [TestCase( "3", "podwójny ser" )]
        public void GetList_CheckGetListSelectOneSides_ReturnOneSide ( int index, string expecteName )
        {
            var form = FormTest.CreateFormMenu();
            var sidesChLBox = new  SidesCheckListBox(form);
            var listSides = FakeCreateFourSides.GetList();
            sidesChLBox.SetList( listSides );
            form.CheckedListBoxSide.SetItemCheckState( index, CheckState.Checked );

            var currentSides = sidesChLBox.GetList();
            var currentCount = currentSides.Count;

            Assert.AreEqual( expecteName, currentSides [0] );
            Assert.AreEqual( 1, currentCount );
        }

        [TestCase()]
        public void GetList_CheckGetListSelectAllSides_ReturnAllSides ()
        {
            var form = FormTest.CreateFormMenu();
            var sidesChLBox = new  SidesCheckListBox(form);
            var listSides = FakeCreateFourSides.GetList();
            sidesChLBox.SetList( listSides );
            form.CheckedListBoxSide.SetItemCheckState( 0, CheckState.Checked );
            form.CheckedListBoxSide.SetItemCheckState( 1, CheckState.Checked );
            form.CheckedListBoxSide.SetItemCheckState( 2, CheckState.Checked );
            form.CheckedListBoxSide.SetItemCheckState( 3, CheckState.Checked );
            var list = sidesChLBox.GetList();

            var currentSides1 = list[0];
            var currentSides2 = list[1];
            var currentSides3 = list[2];
            var currentSides4 = list[3];
            var currentCount = list.Count;

            Assert.AreEqual( "pieczarki", currentSides1 );
            Assert.AreEqual( "salami", currentSides2 );
            Assert.AreEqual( "szynka", currentSides3 );
            Assert.AreEqual( "podwójny ser", currentSides4 );
            Assert.AreEqual( 4, currentCount );
        }

        [TestCase()]
        public void GetList_CheckGetListNotSelectSides_ReturnCountListZero ()
        {
            var form = FormTest.CreateFormMenu();
            var sidesChLBox = new  SidesCheckListBox(form);
            var listSides = FakeCreateFourSides.GetList();
            sidesChLBox.SetList( listSides );
            var list = sidesChLBox.GetList();

            var currentCount = list.Count;

            Assert.AreEqual( 0, currentCount );
        }
    }

    internal class FakeCreateFourSides
    {
        static public List<string> GetList ()
        {
            return new List<string> { "pieczarki", "salami", "szynka", "podwójny ser" };
        }
    }
}

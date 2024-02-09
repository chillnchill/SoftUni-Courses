// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {

        [Test]

        public void Test_StageCtor_ShouldWork()
        {
            Stage stage = new Stage();

            Assert.NotNull(stage.Performers);

        }

        [Test]
        public void Test_StageAddPerformer_ShouldBork()
        {
            Stage stage = new Stage();

            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));

            Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("sto", "sho", 17)));


        }

        [Test]
        public void Test_StageAddPerformer_ShouldWork()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("sto", "sho", 27);
            stage.AddPerformer(performer);

            Assert.AreEqual(1, stage.Performers.Count);
        }


        [Test]
        public void Test_StageAddSong_ShouldBork()
        {
            Stage stage = new Stage();

            Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));

            Assert.Throws<ArgumentException>(() => stage.AddSong
            (new Song("believe", TimeSpan.FromSeconds(20))));

            stage.AddSong(new Song("believe", TimeSpan.FromMinutes(2)));
        }

        [Test]
        public void Test_StageAddSongToPerformer_ShouldWork()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("sto", "sho", 27);
            Song song = new Song("believe", TimeSpan.FromMinutes(2));

            stage.AddPerformer(performer);
            stage.AddSong(song);
            performer.SongList.Add(song);


            Assert.AreEqual("believe (02:00) will be performed by sto sho", stage.AddSongToPerformer(song.Name, performer.FullName));
        }

        [Test]
        public void Test_StageAddSongToPerformer_ShouldBork()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("sto", "sho", 27);
            Song song = new Song("believe" , TimeSpan.FromMinutes(10));

            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "test"));
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("test", null));

            stage.AddPerformer(performer);
            stage.AddSong(song);

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("believe", "go sho"));
            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("recount", "sto sho"));
        }

        [Test]
        public void Test_PlayMethod_ShouldWork()
        {
            Stage stage = new Stage();

            Performer perfOne = new Performer("go", "sho", 30);
            Performer perfTwo = new Performer("sto", "sho", 27);
            Performer perfThree = new Performer("cho", "sho", 37);

            Song song = new Song("believe", TimeSpan.FromMinutes(2));
            Song songTwo = new Song("rekt", TimeSpan.FromMinutes(3));
            Song songThree = new Song("kekd", TimeSpan.FromMinutes(5));
            Song songFour = new Song("leling", TimeSpan.FromMinutes(4));
            Song songFive = new Song("praz mandja", TimeSpan.FromMinutes(3));

            stage.AddPerformer(perfOne);
            stage.AddPerformer(perfTwo);
            stage.AddPerformer(perfThree);
            
            stage.AddSong(song);
            stage.AddSong(songTwo);
            stage.AddSong(songThree);
            stage.AddSong(songFour);
            stage.AddSong(songFive);

            stage.AddSongToPerformer(song.Name, perfOne.FullName);
            stage.AddSongToPerformer(songTwo.Name, perfOne.FullName);
            stage.AddSongToPerformer(songThree.Name, perfOne.FullName);
            stage.AddSongToPerformer(songFour.Name, perfThree.FullName);
            stage.AddSongToPerformer(songFive.Name, perfThree.FullName);

            Assert.AreEqual("3 performers played 5 songs", stage.Play());

        }
    }
}
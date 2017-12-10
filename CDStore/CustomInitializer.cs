using System;
using System.Data.Entity;

namespace CDStore
{
    public class CustomInitializer : DropCreateDatabaseAlways<CDStoreDbContext>
    {
        protected override void Seed(CDStoreDbContext context)
        {
            var fb = CreateArtist(context, "Fred Bates");
            var mo = CreateArtist(context, "Maria Okello");
            var bh = CreateArtist(context, "Bobby Harris");
            var jm = CreateArtist(context, "Jo Morris");
            var jj = CreateArtist(context, "JJ");
            var rap = CreateArtist(context, "Rapport");

            var waterfall = CreateSong(context, "Waterfall", jj, "Americana");
            var shakeIt = CreateSong(context, "Shake it", fb, "Heavy Metal");
            var comeAway = CreateSong(context, "Come Away", bh, "Americana");
            var volcano = CreateSong(context, "Volcano", mo, "Art Pop");
            var complicatedGame = CreateSong(context, "Complicated Game", jj, "Americana");
            var ghostTown = CreateSong(context, "Ghost Town", fb, "Heavy Metal");
            var gentleWaves = CreateSong(context, "Gentle Waves", mo, "Art Pop");
            var rightHere = CreateSong(context, "Right Here", mo, "Art Pop");
            var clouds = CreateSong(context, "Clouds", jm, "Art Pop");
            var sheetSteel = CreateSong(context, "Sheet Steel", rap, "Heavy Metal");
            var hereWithYou = CreateSong(context, "Here with you", bh, "Art Pop");

            var shadows = CreateCD(context, "Shadows", "ABC", "2014/05/06");
            var nightTurnedDay = CreateCD(context, "Night Turned Day", "GHK", "2015/03/24");
            var autumn = CreateCD(context, "Autumn", "ABC", "2015/10/11");
            var basicPoetry = CreateCD(context, "Basic Poetry", "GHK", "2016/02/01");
            var luckyOnes = CreateCD(context, "The Lucky Ones", "DEF", "2016/02/16");
            var luckyMe = CreateCD(context, "Lucky Me", "ABC", "2014/05/24");
            var flyingHigh = CreateCD(context, "Flying High", "DEF", "2015/07/31");

            AddSongsToCD(context, shadows, waterfall,  comeAway, rightHere );
            AddSongsToCD(context, nightTurnedDay, waterfall, complicatedGame, clouds, hereWithYou);
            AddSongsToCD(context, autumn, shakeIt, ghostTown);
            AddSongsToCD(context, basicPoetry, ghostTown, waterfall, complicatedGame, sheetSteel);
            AddSongsToCD(context, luckyMe, shakeIt, volcano, gentleWaves, hereWithYou);
        }

        private Artist CreateArtist(CDStoreDbContext context, string name)
        {
            var a = new Artist() { Name = name };
            context.Artists.Add(a);
            context.SaveChanges();
            return a;
        }

        private Song CreateSong(CDStoreDbContext context, string title, Artist artist, string type)
        {
            var a = new Song() { Title = title, MusicType = type, Artist = artist };
            context.Songs.Add(a);
            context.SaveChanges();
            return a;
        }

        private CD CreateCD(CDStoreDbContext context, string title, string recordCompany, string published)
        {
            var cd = new CD()
              { Title = title, RecordCompany = recordCompany, Published = Convert.ToDateTime(published) };
            context.CDs.Add(cd);
            context.SaveChanges();
            return cd;
        }

        private void AddSongsToCD(CDStoreDbContext context, CD cd, params Song[] songs)
        //'params' signifies that you can add multiple parameters of that type
        {
            foreach (Song song in songs)
            {
               cd.Songs.Add(song);
            }
            context.SaveChanges();
        }
    }
}


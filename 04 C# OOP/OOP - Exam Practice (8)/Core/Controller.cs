using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core.Contracts
{
    public class Controller : IController
    {
        //can prolly delete some
        private readonly IRepository<IBooth> booths;
        private readonly IRepository<ICocktail> cocktails;
        private readonly IRepository<IDelicacy> delicacies;
        public Controller()
        {
            booths = new BoothRepository();
            cocktails = new CocktailRepository();
            delicacies = new DelicacyRepository();
        }
        public string AddBooth(int capacity)
        {
            int id = booths.Models.Count + 1;
            Booth booth = new Booth(id, capacity);
            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, id, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {

            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            string[] availableSizes = { "Small", "Middle", "Large" };
            ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(x => x.Name == cocktailName && x.Size == size);

            if (cocktail != null)
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }
            if (!availableSizes.Contains(size))
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }           
            if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else if (cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            booth.CocktailMenu.AddModel(cocktail);
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);

        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(x => x.Name == delicacyName);

            if (delicacy != null)
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }
            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == nameof(Stolen))
            {
                delicacy = new Stolen(delicacyName);
            }
            else
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            booth.DelicacyMenu.AddModel(delicacy);
            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            throw new NotImplementedException();
        }

        public string LeaveBooth(int boothId)
        {
            throw new NotImplementedException();
        }

        public string ReserveBooth(int countOfPeople)
        {
            List<IBooth> freeBooths = new List<IBooth>();

            foreach (IBooth booth in booths.Models
                .OrderBy(c => c.Capacity >= countOfPeople)
                .ThenByDescending(i => i.BoothId))  
            {
                if (booth.IsReserved == false)
                {
                    freeBooths.Add(booth);
                }
            }
            IBooth firstAvailableBooth = freeBooths.FirstOrDefault();
            if (firstAvailableBooth != null)
            {
                firstAvailableBooth.ChangeStatus();
                return string.Format(OutputMessages.BoothReservedSuccessfully, firstAvailableBooth.BoothId, countOfPeople);
            }
            return string.Format(OutputMessages.BoothNotFound, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            throw new NotImplementedException();
        }
    }
}

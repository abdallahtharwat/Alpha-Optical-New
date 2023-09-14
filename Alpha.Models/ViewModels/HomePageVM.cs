using Alpha.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.Models.ViewModels
{
    public class HomePageVM
    {
        public IEnumerable<Product>  products { get; set; }

        public Header header { get; set; }
        public AboutUs  AboutUs { get; set; }

        public List<Feature>? features { get; set; }
        public List<OtherFeature>?  otherFeatures { get; set; }
        public List<OurClient>  ourClients { get; set; }

        public DetailsSection  DetailsSection { get; set; }

    }
}

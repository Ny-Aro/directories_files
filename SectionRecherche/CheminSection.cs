using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SectionRecherche
{
    public class CheminSection : ConfigurationSection
    {

        #region Fields
        private static ConfigurationPropertyCollection s_properties;
        private static ConfigurationProperty s_propName;
        private static ConfigurationProperty s_propChemins;
        #endregion

        #region Constructor
        static CheminSection()
        {
            s_propName = new ConfigurationProperty(
                "name",
                typeof(string),
                null,
                ConfigurationPropertyOptions.IsRequired
                );
            s_propChemins = new ConfigurationProperty(
                "",
                typeof(CheminElementCollection),
                null,
                ConfigurationPropertyOptions.IsRequired | ConfigurationPropertyOptions.IsDefaultCollection
                );
            s_properties = new ConfigurationPropertyCollection();

            s_properties.Add(s_propName);
            s_properties.Add(s_propChemins);
        }
        #endregion

        #region Properties
        public string NameChemins
        {
            get { return (string)base[s_propName]; }
            set { base[s_propName] = value; }
        }
        public CheminElementCollection Chemins
        {
            get { return (CheminElementCollection)base[s_propChemins]; }
        }
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return s_properties;
            }
        }
        #endregion

    }
}

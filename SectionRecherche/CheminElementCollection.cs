using System;
using System.Configuration;

namespace SectionRecherche
{
    public class CheminElementCollection : ConfigurationElementCollection
    {

        #region Constructor
        public CheminElementCollection()
        {
        }
        #endregion

        #region Properties
        public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMap;
        protected override string ElementName => "chemin";
        protected override ConfigurationPropertyCollection Properties => new ConfigurationPropertyCollection();
        #endregion

        #region Overrides
        protected override ConfigurationElement CreateNewElement()
        {
            return new CheminElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as CheminElement).Source;
        }
        #endregion

    }
}
namespace Bymyslf.IniSettings
{
    public class IniKeyValuePair
    {
        public IniKeyValuePair(IniSection parent, string key, string value)
            : this(parent, key, value, IniStatus.Unchanged)
        { }

        public IniKeyValuePair(IniSection parent, string key, string value, IniStatus status)
        {
            this.parent = parent;
            this.key = key;
            this.keyValue = value;
            this.status = status;
        }

        private IniSection parent;

        public IniSection Parent
        {
            get { return this.parent; }
            protected set { this.parent = value; }
        }

        private string key;

        public string Key
        {
            get { return this.key; }
            protected set { this.key = value; }
        }

        private string keyValue;

        public string Value
        {
            get { return this.keyValue; }
            set
            {
                this.keyValue = value;
                this.status = IniStatus.Modified;
            }
        }

        private IniStatus status;

        public IniStatus Status
        {
            get { return this.status; }
        }

        public void Remove()
        {
            this.status = IniStatus.Removed;
            this.parent.Status = IniStatus.Modified;
        }
    }
}
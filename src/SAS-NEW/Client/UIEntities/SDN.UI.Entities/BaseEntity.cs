namespace SDN.UI.Entities
{
    using System.ComponentModel;
   public class BaseEntity : INotifyPropertyChanged
    {
        #region Private Properties
        private string title;
        private int? createdby;
        private int? modifiedby;
        private int? deletedby;
        private System.DateTime? createdDate;
        private System.DateTime? modifiedDate;
        private System.DateTime? deletedDate;

        public event PropertyChangedEventHandler PropertyChanged;


        #endregion
        #region Public Properties
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        /// 
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
                this.OnPropertyChanged("Title");
            }
        }
        /// <summary>
        /// Created By user id
        /// </summary>
        public int? CreatedBy {
            get
            {
                return this.createdby;
            }

            set
            {
                this.createdby = value;
                this.OnPropertyChanged("CreatedBy");
            }
        }
        /// <summary>
        /// Date when the record created in the database
        /// </summary>
        public System.DateTime? CreatedDate
        {
            get
            {

                return this.createdDate;
            }

            set
            {
                this.createdDate = value;
                this.OnPropertyChanged("CreatedDate");
            }
        }

        public int? ModifiedBy {
            get
            {
                return this.modifiedby;
            }



            set
            {
                this.modifiedby = value;
                this.OnPropertyChanged("ModifiedBy");
            }

        }

        public System.DateTime? ModifiedDate
        {
            get
            {

                return this.modifiedDate;
            }

            set
            {
                this.modifiedDate = value;
                this.OnPropertyChanged("ModifiedDate");
            }
        }

        public int? DeletedBy
        {
            get
            {
                return this.deletedby;
            }



            set
            {
                this.deletedby = value;
                this.OnPropertyChanged("DeletedBy");
            }

        }

        public System.DateTime? DeletedDate
        {
            get
            {

                return this.deletedDate;
            }

            set
            {
                this.deletedDate = value;
                this.OnPropertyChanged("DeletedDate");
            }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity"/> class.
        /// </summary>
        public BaseEntity()
        {

        }
        #endregion

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="name">The name.</param>
        public virtual void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

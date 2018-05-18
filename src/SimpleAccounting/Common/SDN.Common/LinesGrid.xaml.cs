
namespace SDN.Common
{
    
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for LinesGrid.xaml
    /// </summary>
    public partial class LinesGrid : UserControl
    {
        #region Dependency properties
        /// <summary>
        ///     The Columns dependency property identifier.
        /// </summary>
        public static readonly DependencyProperty ColumnsProperty;

        /// <summary>
        ///     The Rows dependency property identifier.
        /// </summary>
        public static readonly DependencyProperty RowsProperty;

        /// <summary>
        ///     The LineThickness dependency property identifier.
        /// </summary>
        public static readonly DependencyProperty LineThicknessProperty;

        public static readonly DependencyProperty LineBrushProperty;
        public static readonly DependencyProperty ColumnsWidthProperty;
        public static readonly DependencyProperty RowsHeightProperty;
        public static readonly DependencyProperty CustomColumnwidthProperty;
        #endregion

        #region Static constructors
        static LinesGrid()
        {
            ColumnsProperty = DependencyProperty.Register("Columns", typeof(int), typeof(LinesGrid), new PropertyMetadata(1, Columns_Changed));
            RowsProperty = DependencyProperty.Register("Rows", typeof(int), typeof(LinesGrid), new PropertyMetadata(1, Rows_Changed));
            LineThicknessProperty = DependencyProperty.Register("LineThickness", typeof(double), typeof(LinesGrid), new PropertyMetadata(1d));
            LineBrushProperty = DependencyProperty.Register("LineBrush", typeof(Brush), typeof(LinesGrid), new PropertyMetadata(Brushes.Black));
           ColumnsWidthProperty = DependencyProperty.Register("ColumnsWidth", typeof(string), typeof(LinesGrid), new PropertyMetadata(string.Empty, Columns_Changed));
            RowsHeightProperty = DependencyProperty.Register("RowsHeight", typeof(int), typeof(LinesGrid), new PropertyMetadata(22, Rows_Changed));

            CustomColumnwidthProperty = DependencyProperty.Register("CustomColumnwidth", typeof(bool), typeof(LinesGrid), new PropertyMetadata(null));
        }
        #endregion

        #region Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="LinesGrid"/> class.
        /// </summary>
        public LinesGrid()
        {
            this.DataContext = this;
            this.InitializeComponent();
            this.Loaded += new RoutedEventHandler(this.LinesGrid_Loaded);
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Gets or sets the number of columns to draw.
        /// </summary>
        /// <value>
        ///     The number of columns.
        /// </value>
        public int Columns
        {
            get
            {
                return (int)this.GetValue(ColumnsProperty);
            }

            set
            {
                this.SetValue(ColumnsProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the quantity of rows to draw.
        /// </summary>
        /// <value>
        ///     The number of rows.
        /// </value>
        public int Rows
        {
            get
            {
                return (int)this.GetValue(RowsProperty);
            }

            set
            {
                this.SetValue(RowsProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the thickness of the lines.
        /// </summary>
        /// <value>
        ///     The line thickness.
        /// </value>
        public double LineThickness
        {
            get
            {
                return (double)this.GetValue(LineThicknessProperty);
            }

            set
            {
                this.SetValue(LineThicknessProperty, value);
            }
        }

        public Brush LineBrush
        {
            get
            {
                return (Brush)this.GetValue(LineBrushProperty);
            }

            set
            {
                this.SetValue(LineBrushProperty, value);
            }
        }

        public bool CustomColumnWidth
        {
            get
            {
                return (bool)this.GetValue(CustomColumnwidthProperty);
            }

            set
            {
                this.SetValue(CustomColumnwidthProperty, value);
            }
        }
        public int RowsHeight
        {
            get
            {
                return (int)this.GetValue(RowsHeightProperty);
            }

            set
            {
                this.SetValue(RowsHeightProperty, value);
            }
        }

        public  string ColumnsWidth
        {
            get
            {
                return (string)this.GetValue(ColumnsWidthProperty);
            }

            set
            {
                this.SetValue(ColumnsWidthProperty, value);
            }
        }
        //
        #endregion

        #region Methods
        /// <summary>
        ///     Handles the Columns change.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        public static void Columns_Changed(object sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as LinesGrid).RecreateLines();
        }

        /// <summary>
        ///     Handles the Rows change.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        public static void Rows_Changed(object sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as LinesGrid).RecreateLines();
        }

        private void LinesGrid_Loaded(object sender, RoutedEventArgs e)
        {
           
            this.RecreateLines();
        }
            

        private void RecreateLines()
        {
            if (this.ActualWidth == 0 || this.ActualHeight == 0)
            {
                return;
            }
            double myRowheight =  this.RowsHeight;
            this.Rows = int.Parse(System.Math.Round(this.ActualHeight /myRowheight - this.LineThickness ).ToString());
             
            double cellWidth = this.ActualWidth / ((this.LineThickness/2) * this.Columns);
            this.verticalLines.Viewbox = new Rect(0, 0, cellWidth, 0.5);

            double cellHeight = this.ActualHeight / ((this.LineThickness / 2) * this.Rows);
            this.horizontalLines.Viewbox = new Rect(0, 0, 0.5, cellHeight);

            double qv = (1d - (this.LineThickness/2) / this.ActualWidth) / this.Columns;
            this.verticalLines.Viewport = new Rect(0, 0, qv, 0.5);

            double qh = (1d - (this.LineThickness/2) / this.ActualHeight) / this.Rows;
            this.horizontalLines.Viewport = new Rect(0, 0, 0.5, qh);
            

        }
        #endregion
    }
}


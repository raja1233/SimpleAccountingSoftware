   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SDN.Product.ViewSDN.Product.View  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      ;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5      1    +SDN.Product.View.PandSCodesAndRatesListView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:SDN.Product.View     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      ;my,clr-namespace:SDN.Common;assembly=SDN.Common     5      $
��1024��5
      $
��Left=�6   
�������.��5      �� $��Stretch=�6   $
��Auto=�62   $
��Auto=�6U   .��5   
   �   � 	Resources  5      9  3SDN.Common.Converter.TextInputToVisibilityConverter "  TextInputToVisibilityConverter,  &SDN.Common.Converter.DateTimeConverter  DateTimeFormatter  BorderStyle �� 
TargetType �� Property �� Value  brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder  StripesBrush j� TileMode j� Viewport j� Viewbox j� ViewportUnits	 j� ViewboxUnits
 !� Visual	 �� X1	 �� X2	 �� Y1	 �� Y2��%  &	        &	      &	 &     &	 �     &	 �     &	 �     &	 �       5      69     5      6H   �� 5      " ��6,   .�5      ��  � ��$ 1q�68   �� 5       � ��
 �   �64   5      �� 5      $ White��6C   �� 5      $
 Gray��6C   �� 5      $ Black��6?   !� 5      $
 Tile=�63   $ 	0,0,20,20�6C   $ 	0,0,10,20�5      $ Absolute=�6$   $	 Absolute=�5      
 5      �� 5      $ 0��6   $ 10000��6&   $ 0��61   $ 20��68   
�������6@   5"      5#       � RowDefinitions 5$      �� 5%      $��40 �6    6.   �� 5'      $	��10* �6!   60   �� 5(      $��40 �6    6.    � ColumnDefinitions 5*      �� 5+      $	��256 �6#   61   �� 5,      $	��256 �6#   61   �� 5-      $	��256 �6#   61   �� 5.      $	��256 �6#   61   .+�5@      ��  �� Orientation$ 
Horizontal=�6   $��0��62   $��2��6B   $��0��6V   $��	12 10 0 0q�6c   .+�5A      	� -   5         	�Name$ radProductYes��5A      $��0 2 10 2q�6Y    	� 	GroupName$ radProductOrService��6m   $��14��6�   $
��Left=�6�   ��65   �� *ShowAllCommand+ d� 	IsChecked 6�   �� *ShowProducts+ �� BindingGroupName$ Group1�� �� UpdateSourceTrigger$ PropertyChanged=�.��6  
Products6"  	� 5B      -   5        $ radServiceYes��5B      $��5 2 10 2q�66   $ radProductOrService��6r   $��15��6�   $
��Left=�6�   ��6H   �� *ShowSelectedCommand+ 6�   �� *ShowServices+$ Group1��$ PropertyChanged=�.��6  
Services6(  	� 5C      -   5        $ 
radBothYes��5C      $��5 2 10 2q�63   $ radProductOrService��6o   $��15��6�   $
��Left=�6�   ��6E   �� *ShowSelectedCommand+ 6�   �� *
ShowBoth+$ Group1��$ PropertyChanged=�.��6  Both6  5D      �� 5F      $	��Top=�6     WaterMarkStyle#��[ 62   $��0��6[   $��1��6k   $��15 5 0 0q�6x   $��Search��6�   #��[ 6�   y�5G      `� 5H       `� 	Converter# [  6#   .1�5I      ��  �� ElementName$ cmbPandSCode��6"    �� Path$ Text.IsEmpty�6=   �� 5J      $ cmbPandSCode��6"   $ 	IsFocused�6=   5K      5M      �� 5N      -   5        $��cmbPandSCode��5Q   S   
������ #��[ 5N   0   $��0��6d   $��1��6t   $��13 0 0 0q�6�    �� 
IsEditable . $
��Left=�5O      $��30��62   $	��Top=�6A   $	��235��6Y   $	��235��6h    �� DisplayMemberPath$ 	PandSCode��5Q       �� SelectedValuePath$ 	PandSCode��65   ��5P      �� *PandSCodesAndRatesListcmbCode+ �� SelectedValue 5R      �� *SelectedPandSCode+5S      �� 5T      $	��Top=�6   #��[ 62   $��1��6\   $��2��6l   $��1��6�   $��-5 5 0 0q�6�   $��Search��6�   #��[ 6�   y�5U      `� 5V      # [  6#   .1�5W      �� $ cmbPandSName��6"   $ Text.IsEmpty�6=   �� 5X      $ cmbPandSName��6"   $ 	IsFocused�6=   5Y      5[      �� 5\      -   5        $��cmbPandSName��5_   S   
������ #��[ 5\   0   $��1��6d   $��2��6t   $��1��6�   $��-7 0 0 0q�6�    . $
��Left=�5]      $��30��62   $	��Top=�6A   $	��235��6Y   $	��235��6h   $ 	PandSName��5_      $ 	PandSName��65   ��5^      �� *PandSCodesAndRatesListcmb+ 5`      �� *SelectedPandSName+5a      �� 5b      -   5        $��cmb1Cat1��5e   S   
������ #��[ 5b   0   $��2��6d   $��2��6t   $��1��6�   $��	-27 0 0 0q�6�    . $
��Left=�5c      $��30��62   $	��Top=�6A   $	��128��6Y   $	��128��6h   $ 	Category1��5e      $ 	Category1��65   ��5d      �� *PandSCodesAndRatesListcmbCat1+ 5f      �� *SelectedCategory1+5g      �� 5h      -   5        $��cmb1Cat2��5k   S   
������ #��[ 5h   0   $��2��6d   $��2��6t   $��1��6�   $��	103 0 0 0q�6�    . $
��Left=�5i      $��30��62   $	��Top=�6A   $	��125��6Y   $	��125��6h   $ 	Category2��5k      $ 	Category2��65   ��5j      �� *PandSCodesAndRatesListcmbCat2+ 5l      �� *SelectedCategory2+5m      �� 5n      -   5        $��
cmbTaxCode��5q   S   
������ #��[ 5n   0   $��3��6d   $��1��6t   $��	-26 0 0 0q�6�    . $
��Left=�5o      $��30��62   $	��Top=�6A   $	��125��6Y   $	��125��6h   $ 	PSTaxName��5q      $ 	PSTaxName��65   ��5p      �� * PandSCodesAndRatesListcmbTCode+ 5r      �� *SelectedPSTaxName+5s      �� 5t      -	   5        $��
cmbTaxRate��5w   S   
������ #��[ 5t   0   $��3��6d   $��1��6t   $��
100  0 0 0q�6�    . $
��Left=�5u      $��30��62   $	��Top=�6A   $	��125��6Y   $	��125��6h   $ 	PSTaxRate��5w      $ 	PSTaxRate��65   ��5v      �� * PandSCodesAndRatesListcmbTRate+ 5x      �� *SelectedPSTaxRate+5y      �� 5z      $��1��6   $��0��6&   $��4��66   $��0,30,2,0q�6K   .+�5{      � .+�5|      &   System.Windows.Controls.DataGrid  -
   5          Name$ CustomGridLines��5|      $��0��6g      GridLinesVisibility$	 All=�5}   P       HorizontalGridLinesBrush
  �����!   VerticalGridLinesBrush
! �����"   AutoGenerateColumns" .  $#   HorizontalScrollBarVisibility$# Hidden=�5      "$   VerticalScrollBarVisibility$$ Disabled=�6C     BackHeaderStyle20%   ColumnHeaderStyle#% [ 5�      &   HeadersVisibility$	& All=�6R   ��5|   8   �� *PandSCodesAndRatesList+��5}      �� $	 dg1��$ ActualHeight���6l   �� $	 dg1��$ ActualWidth�'   Columns' 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn(   Header$(  ��61   )   Width5  /System.Windows.Controls.DataGridLengthConverter$	) 235 6U   1  +System.Windows.Controls.DataGridBoundColumn*   Binding* 6;   �� *Col0+6c     5�      $(  ��61   $	) 235 6U   * 6;   �� *Col1+6c     5�      $(  ��61   $	) 130 6U   * 6;   �� *Col2+6c     5�      $(  ��61   $	) 130 6U   * 6;   �� *Col3+6c     5�      $(  ��61   $	) 126 6U   * 6;   �� *Col4+6c     5�      $(  ��61   $	) 126 6U   * 6;   �� *Col5+6c   5�        5�      -   5        $	 dg1��5�   F   
������ + �� IsTextSearchEnabled+ . $	��997��5�   T   $��Visible=�6`   $# Hidden=�5�      $��0��6c   $	 All=�5�      $��1q�62   ,   CanUserAddRows, .   	 HeaderStyle20#% [	 5�      -   CanUserDeleteRows- .  .   SelectionMode$. Single=�6l   $	��Top=�6�   " .  ��5�   D   �� *
GridHeight+��5�   S   �� *PandSCodesAndRatesList+' 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      -   5        	PandSCode��$	) 235 5�   H   /   MaxWidth$	/ 235Q�6T   0   MinWidth$	0 235Q�6c   $( Product and Service Code��6s   1   SortMemberPath$1 	PandSCode��6�   2   HeaderTemplate2 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   6B    5�   .   �� 5�   2   ��6C   �� $ 	PandSCode��$ ActualWidth�.+�5�   .   ]� $��0��68   $��0��6E   .+�5�   2   �� #��z��6<   5�   3   �� 5�   2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�   1   $��20��6<   $
��Left=�5�   ,   5�   /   5�   +   5�   '   3   CellTemplate3 5�   "   �� 5�   &   .R�5�   *   �� �� 5�   ,   4 �� Command4 66   �� *(&DataContext.NavigateToPandSFormCommand+5 �� RelativeSource5 �� 6 �� AncestorType"6 >�7 �� CommandParameter7 5�   2   �� *	PandSCode+.�6Y   .�5�   2   �� $
��Wrap=�6W   $
��None{�6k   ��6<   �� *	PandSCode+6k   5�   .   5�   *   5�   '   5�        5�      -   5        	PandSName��$	) 235 5�   H   $	/ 235Q�6T   $	0 235Q�6c   $( Product and Service Name��6s   $1 	PandSName��6�   2 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   6B    5�   .   �� 5�   2   ��6C   �� $ 	PandSName��$ ActualWidth�.+�5�   .   ]� $��0��68   $��0��6E   .+�5�   2   �� #��z��6<   5�   3   �� 5�   2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�   1   $��20��6<   $
��Left=�5�   ,   5�   /   5�   +   5�   '   3 5�   "   �� 5�   &   .R�5�   *   �� �� 5�   ,   4 66   �� *(&DataContext.NavigateToPandSFormCommand+5 �� "6 >�7 5�   2   �� *	PandSName+.�6Y   .�5�   2   �� $
��Wrap=�6W   $
��None{�6k   ��6<   �� *	PandSName+6k   5�   .   5�   *   5�   '   5�        5�      -   5        	Category1��$	0 130Q�5�   H   $	/ 130Q�6W   $( 
Category 1��6f   $
) Auto 6{   8   CanUserSort8 .  $1 	InvoiceNo��5�   D   2 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   6B    5�   .   �� 5�   2   ��6C   �� $ 	Category1��$ ActualWidth�.+�5�   .   ]� $��0��68   $��0��6E   .+�5�   2   �� #��z��6<   $��20��6]   5�   3   5�   /   5�   +   5�   '   3 5�   "   �� 5�   &   .R�5�   *   �� $
��Left=�64   $
��Wrap=�6j   ��6O   �� *	Category1+6j   5�   '   5�        5�      -   5        	Category2��8 .  $	) 130 5�   X   $	/ 130Q�6d   $	0 130Q�6s   $( 
Category 2��6�   * 6�   �� $ 	Category2�2 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   6B    5�   .   �� 5�   2   ��6C   �� $ 	Category2��$ ActualWidth�.+�5�   .   ]� $��0��68   $��0��6E   .+�5�   2   �� #��z��6<   $��20��6]   5�   3   5  /   5  +   5  '   9   ElementStyle9 5  "   �� 5  &   " ��6,   .�5	  *   ��  � ��$
 Left=�6P   5
  '   5       5     -   5        TaxCode��$	) 126 5  F   $	/ 126Q�6R   $	0 126Q�6a   $1 	PSTaxName��6q   2 5  "   �� 5  &   .R�5  *   �  5  .   �� 5  2   6B    5  .   �� 5  2   ��6C   �� $ TaxCode��$ ActualWidth�.+�5  .   ]� $��0��68   $��0��6E   .+�5  2   �� �� 5  6   �6:   �� *DataContext.TaxName+5 �� $6 DataGridL�5  R    �� 5  6   $
�Code��6:   6H   5  3   �� 5  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5  1   $��20��6<   $
��Left=�5   ,   5!  /   5#  +   5$  '   3 5&  "   �� 5'  &   .R�5(  *   �� �� 5*  2   $
��Wrap=�6W   $
��None{�6k   ��6<   �� *	PSTaxName+6k   5,  *   5-  '   50       51     -   5        TaxRate��$	) 125 51  F   $	/ 125Q�6R   $	0 125Q�6a   $1 	PSTaxRate��6q   2 52  "   �� 53  &   .R�54  *   �  55  .   �� 56  2   6B    59  .   �� 5:  2   ��6C   �� $ TaxRate��$ ActualWidth�.+�5<  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5=  2   �� �� 5>  6   �6:   �� *DataContext.TaxName+5 �� $6 DataGridL�5?  R    �� 5@  6   $
�Rate��6:   6H   5A  3   �� 5C  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5D  1   $��20��6<   $
��Left=�5E  ,   5F  /   5H  +   5I  '   3 5K  "   �� 5L  &   .R�5M  *   �� $��Right=�64   �� 5O  2   $
��Wrap=�6W   $
��None{�6k   ��6<   �� *	PSTaxRate+6k   5Q  *   5R  '   5T     5V     5W     5X     �� 5[     $ 
Horizontal=�6   $��3��62   $��2��6B   $��Right=�6O   $��
10,10,10,0q�6l   $��Bottom=�6�   .+�5\     �� $	��New��6   $
��10 0q�6(    
 ButtonStyle#��� 
 66   $	��New��6�   ��6\   �� *NavigaetoPandSNewCommand+6�   �� 5]     $��Close��6   $��10 0 0 0q�6P   #��� 
 6b   ��6)   �� $ CloseCommand�6b   5^     5_     5`     5a     
   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SDN.Sales.ViewsSDN.Sales.Views  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      ;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5      ,    &SDN.Sales.Views.SalesQuotationListView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:SDN.Sales.Views     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      ;my,clr-namespace:SDN.Common;assembly=SDN.Common     5      $
��1024��5
      $
��Left=�6   
�������.��5      �� $��Stretch=�6   $
��Auto=�62   $
��Auto=�6U   .��5   
   �   � 	Resources  5      9  3SDN.Common.Converter.TextInputToVisibilityConverter "  TextInputToVisibilityConverter,  &SDN.Common.Converter.DateTimeConverter  DateTimeFormatter  BorderStyle �� 
TargetType �� Property �� Value  brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder��%+  &	        &	      &	 &     &	 �     &	 �     &	 �       5      69     5      6H   �� 5      " ��6,   .�5      ��  � ��$ 1q�68   �� 5       � ��
 �   �64   5      �� 5      $ White��6C   �� 5      $
 Gray��6C   �� 5      $ Black��6?   5       � RowDefinitions 5      �� 5      $��69 �6    6.   �� 5      $��0 �6    6-   �� 5      $��0 �6    6-   �� 5       $
��Auto �6    60   �� 5!      $��40 �6    6.    � ColumnDefinitions 5#      �� 5$      6%   �� 5%      6%   �� 5&      6%   �� 5'      6%   .+�50      ��  �� Orientation$ 
Horizontal=�6   $��0��62   $��4��6B   $��0��6V   $��	10 10 0 0q�6c   .+�51      	� -   5         	�Name$ radShowAllYes��51      $��0 2 10 2q�6Y   	 	� 	GroupName$	 
radShowAll��6m   $��14��6�   $
��Left=�6�   ��65   �� *ShowAllCommand+
 d� 	IsChecked
 6�   �� *ShowAllTrue+ �� BindingGroupName$ Group1�� �� UpdateSourceTrigger$ PropertyChanged=�.��52      ]� .+�53      �� $��	Show All ��6%   68   �� 54      $�� ��6%   6/   55      56      ]� 5?      $��0��6   $��4��6,   $��2��6@   $��1��6Q   $	��600��5@      $	��600��6(   $
��Left=�67   $��10 0 0 0q�6R   .+�5A      � $	��300��6   $	��300��6,    5B      �� 5C      $
��.25* �6/   6>   �� 5D      61   �� 5E      61   �� 5F      61    5H      �� 5I      6.   �� 5J      6.   .+�5L      	� -   5        $ radyearmonthYes��5L   C   $��0��6&   $��0��63   $	 radSelectionparameter��6\   $��0 0 5 0q�6~   ��5M      �� *YearQuarterSelectedCommand+
 6G   �� *YearmonthQuartTrue+$ Group1��$ PropertyChanged=�6�   �� 5N      $��0��6$   $��1��61   $��Center=�6A   $��Center=�6^   $
��Year��6y   6�   �� 5O      $��0��6$   $��2��61   $��Center=�6A   $��Center=�6^   $��Quater��6y   6�   �� 5P      $��0��6$   $��3��61   $��Center=�6A   $��Center=�6^   $��Month��6y   6�   �� 5Q      -   5        $��cmbYearSearch��5S   I   
���   �$��1��5Q   7   $��1��6D    �� 
IsEditable .  �� DisplayMemberPath$
 Year��5S       �� SelectedValuePath$
 Year��60   {�5Q   T   �� *EnableYearDropDown+��5R      �� *	YearRange+ �� SelectedValue 5T      �� *SelectedSearchYear+ �� Mode$ TwoWay=�$ PropertyChanged=�6w   �� 5U      -   5        $��cmbQuarterSearch��5Z   J   
���   �$��1��5U   7   $��2��6D    .  �� IsTextSearchEnabled .   �� IsTextSearchCaseSensitive .   �� StaysOpenOnEdit . $ Quarter��5Z      $ ID��63   {�5U   T   �� *EnableQuarterDropDown+ w� TextPath 5X      �� *	Quarter+��5Y      �� *QuarterList+ 5[      �� *SelectedSearchQuarter+$ TwoWay=�$ PropertyChanged=�6z   �� 5\      -   5        $��cmbMonthSearch��5^   H   
���   �$��1��5\   7   $��3��6D    . $ Month��5^      $ ID��61   {�5\   T   �� *EnableMonthDropDown+��5]      �� *	MonthList+ 5_      �� *SelectedSearchMonth+$ TwoWay=�$ PropertyChanged=�6x   �� 5`      $��1��6!   $��0��61   #��[ 6>   6e   �� 5a      $��1��6!   $��1��61   #��[ 6>   6e   �� 5b      $��2��6!   $��0��61   #��[ 6>   6e   �� 5c      $��2��6!   $��1��61   #��[ 6>   6e   �� 5d      $��3��6!   $��0��61   #��[ 6>   6e   �� 5e      $��3��6!   $��1��61   #��[ 6>   6e   5f      � 5g      $	��300��6   $	��300��6+   $��10,0,0,0q�6:    5h      �� 5i      6.   �� 5j      6.    5l      �� 5m      $
��.30* �6/   6>   �� 5n      61   �� 5o      61   .+�5q      	� $��0��6&   $��0��63   $��
20 0  5 0 q�6C   $	 radSelectionparameter��6W   ��5r      �� *CalendarSelectionCommand+
 6J   �� *StartEndDateTrue+$ Group1��$ PropertyChanged=�6�   �� 5s      $��0��6$   $��1��61   $��
Start Date��6A   6U   �� 5t      $��1��6$   $��1��61   $��End Date��6A   6S   (  "System.Windows.Controls.DatePicker  5u      -   5        $
��Left=�5u   O   $	��150��6j   $	��150��6y   $��	-50 0 5 5q�6�   $��0��6�   $��2��5w      {�5u   %   �� *EnableStartDropDown+   SelectedDate 5w   -   �� *SelectedSearchStartDate+  5y      :  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name �� 
IsReadOnly  BaseBorderBrush `� 	Converter �� Path �� RelativeSource �� AncestorType��%�  '        7  �� 5z   "   "  6(   .�5{   &   ��  � �� 5|   *   �� 5}   .   .R�5~   2   �� $ PART_TextBox��6:    . $��0q�6b   $��Stretch=�6v   $��Stretch=�6�   #���  6�   .��6�   ��5   6   `� 5�   :   8   .1�5�   >   �� $ SelectedDate�6F   �� 5�   >   $ 
DateFormat�6F   6Z   �� 5�   >   $) #DataContext.SelectedSearchStartDate�6F    5�   A   �� "  5�   ;   .��5�   D   5�   3   5�   /   5�   '   5�   #   5�      5�        5�      -   5        $
��Left=�5�   M   $	��150��6h   $	��150��6w   $��	-50 0 5 5q�6�   $��1��5�   �   $��2��6�   {�5�   %   �� *EnableEndDropDown+   DisplayDateStart 5�   h   �� *EndDateValidation+ 6�   �� *SelectedSearchEndDate+  5�      ��%�  '        7  �� 5�   "   "  6(   .�5�   &   ��  � �� 5�   *   �� 5�   .   .R�5�   2   �� $ PART_TextBox��6:    . $��0q�6b   $��Stretch=�6v   $��Stretch=�6�   #���  6�   .��6�   ��5�   6   `� 5�   :   8   .1�5�   >   �� $ SelectedDate�6F   �� 5�   >   $ 
DateFormat�6F   6Z   �� 5�   >   $' !DataContext.SelectedSearchEndDate�6F    5�   A   �� "  5�   ;   .��5�   D   5�   3   5�   /   5�   '   5�   #   5�      5�      5�      5�      ]� 5�      $��0��6   $��3��6)   $��0 0 0 0q�69   $��2��6J   $��2��6^   .+�5�      �� $!��Select a Start and End date��6    
�������$��Italic$�6U   6k   5�      5�      �� 5�      $	��Top=�6     WaterMarkStyle#��[ 62   $��0��6[   $��3��6l   $��	18 13 0 0q�6y   $��Search��6�   #��[ 6�   y�5�      `� 5�      # [  6#   .1�5�      ��  �� ElementName$ cmbSuppNameSearch��6"   $ Text.IsEmpty�6B   �� 5�      $ cmbSuppNameSearch��6"   $ 	IsFocused�6B   5�      5�      �� 5�      -   5        $��cmbSuppNameSearch��5�   Y   
������ #��[ 5�   0   $��0��6d   $��3��6t    . $��	12 10 0 0q�6�   $
��Left=�6�   $��30��6�   $	��Top=�6�   $	��271��6�   $	��271��6�   $ CustomerName��5�      $ CustomerName��68   ��5�      �� *SalesQuotationListcmbSup+ 5�      �� *SelectedSearchSupName+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $	��Top=�6   #��[ 62   $��1��6[   $��3��6k   $��
133 13 0 0q�6x   $��Search��6�   #��[ 6�   y�5�      `� 5�      # [  6#   .1�5�      �� $ cmbQuotNoSearch��6"   $ Text.IsEmpty�6@   �� 5�      $ cmbQuotNoSearch��6"   $ 	IsFocused�6@   5�      5�      �� 5�      -	   5        $��cmbQuotNoSearch��5�   W   
������ #��[ 5�   1   $��1��6e   $��3��6u    . $
��Left=�6�   $��
126 10 0 0q�6�   $��30��6�   $	��Top=�6�   $	��180��6�   $	��180��6�   $ QuotationNo��5�      $ QuotationNo��67   ��5�      �� *SalesQuotationListcmbQNo+ 5�      �� *SelectedSearchSupName+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $	��Top=�6   $��3��61   $��Right=�6>   $��	0,13,15,0q�6Z   $��Search��6m   #��[ 5�      #��[ 6B   y�5�      `� 5�      # [  6#   .1�5�      �� $ cmbConvertedtoSearch��6"   $ Text.IsEmpty�6E   �� 5�      $ cmbConvertedtoSearch��6"   $ 	IsFocused�6E   5�      5�      �� 5�      -
   5        $��cmbConvertedtoSearch��5�   M   
������ #��[ 5�   1   $��3��6e    . $
��Left=�6�   $��
284,10,0,0q�6�   $��30��6�   $	��Top=�5�      $	��167��6/   $	��180��6>   $��2��5�   �    6   �� *SelectedSearchConvertedTo+$ TwoWay=�$ PropertyChanged=�.@�5�      �� .��6   All6$   �� 5�      .��6   Not Converted6.   �� 5�      .��6   Converted to SO60   �� 5�      .��6   Converted to SI60   5�      �� 5�      $��3��6   $��0��6'   $��4��67   $��	0,40,10,0q�6K   $	��988��6^   .+�5�      � .+�5�      &   System.Windows.Controls.DataGrid  -   5          Name$ CustomGridLines��5�      $��0��6`       GridLinesVisibility$	  All=�5�   P   !   HorizontalGridLinesBrush
! �����"   VerticalGridLinesBrush
" �����#   AutoGenerateColumns# .  $$   HorizontalScrollBarVisibility$$ Hidden=�5�      "%   VerticalScrollBarVisibility$% Disabled=�6C     BackHeaderStyle20&   ColumnHeaderStyle#& [ 5�      '   HeadersVisibility$	' All=�6R   $��0,0,0,0q�6j   ��5�   8   �� *BackGroundLines+��5�      �� $	 dg1��$ ActualHeight���6l   �� $	 dg1��$ ActualWidth�(   Columns( 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn)   Header$)  ��61   *   Width5  /System.Windows.Controls.DataGridLengthConverter$	* 270 6T   1	  +System.Windows.Controls.DataGridBoundColumn+ 	  Binding+ 6;   �� *Col0+6b     5�      $)  ��61   $	* 180 6U   + 6;   �� *Col1+6c     5�      $)  ��61   $	* 180 6U   + 6;   �� *Col2+6c     5�      $)  ��61   $	* 180 6U   + 6;   �� *Col3+6c     5�      $)  ��61   $	* 162 6U   + 6;   �� *Col4+6c   5�        5�      -   5        $	 dg1��5�   �   $��5��6   $	��100��63    . $	  All=�6~   $��1q�6�   ,   CanUserAddRows, .  -   CanUserDeleteRows- .  .   CanUserResizeColumns. .   	 HeaderStyle20#& [	 5�      $$ Disabled=�6K   
������ /   CanUserReorderColumns/ .  0   SelectionMode$0 Single=�6�   $	��Top=�6�   # .  ��5�   C   �� *SQGridHeight+��6�   �� *SalesQuotationList+( 5�      4
  .System.Windows.Controls.DataGridTemplateColumn
  5      -   5        CustomerName��1   MinWidth$	1 270Q�5   K   2   MaxWidth$	2 270Q�6Z   $) Customer Name��6i   $
* Auto 6�   3   SortMemberPath$3 CustomerName��6�   4   HeaderTemplate4 5  "   �� 5  &   .R�5  *   �  5  .   �� 5  2   $
��auto �6C   �� 5  2   $��10 �6D   .+�5  .   �� #��z��68   �� 5	  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5
  1   $��20��6<   $
��Left=�5  ,   $��1��5  ,   5  +   5  '   5 
  CellTemplate5 5  "   �� 5  &   .R�5  *   �� �� 5  ,   6 �� Command6 66   �� *%#DataContext.NavigateToClientCommand+ �� " >�7 �� CommandParameter7 5  2   �� *Cus_ID+.�6V   .�5  2   �� ��6<   �� *CustomerName+5  .   5  *   5  '   5     
  5     -   5        ConvertedTo��$	1 180Q�5  J   $	2 180Q�6Y   $) Status��6h   $3 Status��6x    
 HeaderStyle20Right8   HeaderStyle#8 [
 6�   4 5  "   �� 5  &   .R�5  *   �  5   .   �� 5!  2   $
��auto �6C   �� 5"  2   $��10 �6D   .+�5$  .   �� #��z��68   �� 5%  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5&  1   $��20��6<   $
��Left=�5'  ,   $��1��5(  ,   5*  +   5+  '   5 5-  "   �� 5.  &   .R�5/  *   �� $��Right=�64   �� 50  ,   6 66   �� **(DataContext.NavigateToConvertedToCommand+ �� " >�7 51  2   �� *ConvertedToNo+.�6]   .�52  2   �� $
��Wrap=�6[   $��Right=�6o   ��6<   �� *ConvertedToNo+6o   53  .   54  /   55  '   57     
  59     -   5        QuotationNo��$	1 180Q�59  J   $	2 180Q�6Y   $) Quotation No.��6h   $3 SortQuotationNo��6   $
* Auto 6�   #8 [
 6�   4 5:  "   �� 5;  &   .R�5<  *   �  5=  .   �� 5>  2   $
��auto �6C   �� 5?  2   $��10 �6D   .+�5A  .   �� #��z��68   �� 5B  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5C  1   $��20��6<   $
��Left=�5D  ,   $��1��5E  ,   5G  +   5H  '   5 5J  "   �� 5K  &   .R�5L  *   �� $��Right=�64   �� 5M  ,   6 66   �� *#!DataContext.NavigaetoSalesCommand+ �� " >�7 5N  2   �� *QuotationNo+.�6[   .�5O  2   �� ��6<   �� *QuotationNo+5P  .   5Q  *   5R  '   5T     
  5V     -   5        QuotationDate��$	1 180Q�5V  L   $	2 180Q�6[   $) Quotation Date��6j   $3 QuotationDateDateTime��6�   $
* Auto 6�   #8 [
 6�   4 5X  "   �� 5Y  &   .R�5Z  *   �  5[  .   �� 5\  2   $
��auto �6C   �� 5]  2   $��10 �6D   .+�5_  .   �� #��z��68   $��Right=�6Y   �� 5`  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5a  1   $��20��6<   $��Right=�5b  ,   $��1��5c  ,   5e  +   5f  '   5 5h  "   �� 5i  &   .R�5j  *   �� $��Right=�6T   ��64   �� *QuotationDate+6T   5k  '   5m     
  5n     -   5        QuotationAmount��$	1 162Q�5n  N   $	2 162Q�6]   $) Quotation Amount��6l   $3 QuotationAmount��6�   $
* Auto 6�   #8 [
 6�   4 5o  "   �� 5p  &   .R�5q  *   �  5r  .   �� 5s  2   $
��auto �6C   �� 5t  2   $��10 �6D   .+�5v  .   �� #��z��68   �� 5w  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5x  1   $��20��6<   $
��Left=�5y  ,   $��1��5z  ,   5|  +   5}  '   5 5  "   �� 5�  &   .R�5�  *   �� $��Right=�6V   ��64   �� *QuotationAmount+6V   5�  '   5�     5�     5�     �� 5�     $ 
Horizontal=�6   $
��left=�67   $��0,1,0,0q�6R   $��20��6c   .+�5�     � ��6   �� $ CustomerName��$ ActualWidth�.+�5�     ��   BorderStyleLeft#��[ 6!   ._�5�     �� $��Total��6)   $
��Bold"�66   6J   5�     5�     � 5�     ��6   �� $ QuotationNo��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $�� ��6(   63   5�     5�     � 5�     ��6   �� $ QuotationDate��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     ��   DisplayTotalStyle#��[ 6{   ��6(   �� *ShowSelectedCount+$ TwoWay=�$ PropertyChanged=�6�   5�     5�     � 5�     ��6   �� $ QuotationAmount��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $�� ��6(   64   5�     5�     � 5�     ��6   �� $ ConvertedTo��$ ActualWidth�.+�5�     ��   BorderStyleRight#��[ 6!   ._�5�     �� #��[ 6u   ��6(   �� *TotalAmount+$ TwoWay=�$ PropertyChanged=�6�   5�     5�     5�     5�     �� 5�     $��10 0 0 0q�6   $��4��6+   $��0��68   $��3��6H   $ 
Horizontal=�6\   $
��Left=�6u   $��Bottom=�6�   .+�5�     �� $��Italic$�6   
��������� 5�     $�Amounts include��6   63    �� 5�     �6   �� *	TaxName+65   5�     �� 5�     $��  Amounts are in  ��6   $��Italic$�67   
�������6^   �� 5�     $��Italic$�6:   
���������6   �� *CurrencyName+6a   �� 5�     $��10 0 0 0q�6   $*��$SO : Sales Order  SI : Sales Invoice��6.   $��Italic$�6Z   
�������6�   5�     �� 5�     $ 
Horizontal=�6   $��3��64   $��4��6F   $��Right=�6S   $��
10,0,23,10q�6p   $��Bottom=�6�   .+�5�     �� $	��New��6   $
��10 0q�6(     ButtonStyle#���  66   $	��New��6�   ��6\   �� *NavigaetoSalesCommand+6�   �� 5�     $��Close��6   9 �� IsCancel9 . $��10 0 0 0q�6Z   #���  6l   ��6)   �� *CloseCommand+6l   5�     5�     5�     5�     
   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SDN.Customers.ViewsSDN.Customers.Views  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      ;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5      2    ,SDN.Customers.Views.PandSSoldToCustomersView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:SDN.Customers.Views     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      ;my,clr-namespace:SDN.Common;assembly=SDN.Common     5      $
��1024��5
      $
��Left=�6   
�������.��5      �� $��Stretch=�6   $
��Auto=�62   $
��Auto=�6U   $��0,0,-10,-42q�6z   .��5   
   �   � 	Resources  5      9  3SDN.Common.Converter.TextInputToVisibilityConverter "  TextInputToVisibilityConverter,  &SDN.Common.Converter.DateTimeConverter  DateTimeFormatter  BorderStyle �� 
TargetType �� Property �� Value  brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder��%+  &	        &	      &	 &     &	 �     &	 �     &	 �       5      69     5      6H   �� 5      " ��6,   .�5      ��  � ��$ 1q�68   �� 5       � ��
 �   �64   5      �� 5      $ White��6C   �� 5      $
 Gray��6C   �� 5      $ Black��6?   5       � RowDefinitions 5      �� 5      $��69 �6    6.   �� 5      $��0 �6    6-   �� 5      $��0 �6    6-   �� 5       $��40 �6    6.   �� 5!      $
��Auto �6    60   �� 5"      $��40 �6    6.    � ColumnDefinitions 5$      �� 5%      $	��256 �6#   61   �� 5&      $	��256 �6#   61   �� 5'      $	��256 �6#   61   �� 5(      $	��256 �6#   61   .+�5*      ��  �� Orientation$ 
Horizontal=�6   $��0��62   $��4��6B   $��0��6V   $��	10 10 0 0q�6c   .+�5+      	� -   5         	�Name$ radShowAllYes��5+      $��0 2 10 2q�6Y   	 	� 	GroupName$	 
radShowAll��6m   $��14��6�   $
��Left=�6�   ��65   �� *ShowAllCommand+
 d� 	IsChecked
 6�   �� *ShowAllTrue+ �� BindingGroupName$ Group1�� �� UpdateSourceTrigger$ PropertyChanged=�.��5,      ]� .+�5-      �� $��	Show All ��6%   68   �� 5/      $�� ��6%   6/   50      51      ]� 5:      $��0��6   $��4��6(   $��2��6<   $��1��6M   $	��600��5;      $	��600��6(   $
��Left=�67   $��10 0 0 0q�6R   .+�5<      � $	��300��6   $	��300��6(    5=      �� 5>      $
��.25* �6+   6:   �� 5?      6-   �� 5@      6-   �� 5A      6-    5C      �� 5D      6*   �� 5E      6*   .+�5G      	� -   5        $ radyearmonthYes��5G   ?   $��0��6"   $��0��6/   $	 radSelectionparameter��6X   $��0 0 5 0q�6z   ��5H      �� *YearQuarterSelectedCommand+
 6G   �� *YearmonthQuartTrue+$ Group1��$ PropertyChanged=�6�   �� 5I      $��0��6    $��1��6-   $��Center=�6=   $��Center=�6Z   $
��Year��6u   6�   �� 5J      $��0��6    $��2��6-   $��Center=�6=   $��Center=�6Z   $��Quater��6u   6�   �� 5K      $��0��6    $��3��6-   $��Center=�6=   $��Center=�6Z   $��Month��6u   6�   �� 5L      -   5        $��cmbYearSearch��5N   I   
���   �$��1��5L   3   $��1��6@    �� 
IsEditable .  �� DisplayMemberPath$
 Year��5N       �� SelectedValuePath$
 Year��60   {�5L   P   �� *EnableYearDropDown+��5M      �� *	YearRange+ �� SelectedValue 5O      �� *SelectedSearchYear+ �� Mode$ TwoWay=�$ PropertyChanged=�6w   �� 5P      -   5        $��cmbQuarterSearch��5U   J   
���   �$��1��5P   3   $��2��6@    .  �� IsTextSearchEnabled .   �� IsTextSearchCaseSensitive .   �� StaysOpenOnEdit . $ Quarter��5U      $ ID��63   {�5P   P   �� *EnableQuarterDropDown+ w� TextPath 5S      �� *	Quarter+��5T      �� *QuarterList+ 5V      �� *SelectedSearchQuarter+$ TwoWay=�$ PropertyChanged=�6z   �� 5W      -   5        $��cmbMonthSearch��5Y   H   
���   �$��1��5W   3   $��3��6@    . $ Month��5Y      $ ID��61   {�5W   P   �� *EnableMonthDropDown+��5X      �� *	MonthList+ 5Z      �� *SelectedSearchMonth+$ TwoWay=�$ PropertyChanged=�6x   �� 5[      $��1��6   $��0��6-   #��[ 6:   6a   �� 5\      $��1��6   $��1��6-   #��[ 6:   6a   �� 5]      $��2��6   $��0��6-   #��[ 6:   6a   �� 5^      $��2��6   $��1��6-   #��[ 6:   6a   �� 5_      $��3��6   $��0��6-   #��[ 6:   6a   �� 5`      $��3��6   $��1��6-   #��[ 6:   6a   5a      � 5b      $	��300��6   $	��300��6'   $��10,0,0,0q�66    5c      �� 5d      6*   �� 5e      6*    5g      �� 5h      $
��.30* �6+   6:   �� 5i      6-   �� 5j      6-   .+�5l      	� $��0��6"   $��0��6/   $��
20 0  5 0 q�6?   $	 radSelectionparameter��6S   ��5m      �� *CalendarSelectionCommand+
 6J   �� *StartEndDateTrue+$ Group1��$ PropertyChanged=�6�   �� 5n      $��0��6    $��1��6-   $��
Start Date��6=   6Q   �� 5o      $��1��6    $��1��6-   $��End Date��6=   6O   (  "System.Windows.Controls.DatePicker  5p      -   5        $
��Left=�5p   H   $	��150��6c   $	��150��6r   $��	-60 0 5 5q�6�   $��0��6�   $��2��5r      {�5p   !   �� *StartEndDateTrue+   SelectedDate 5r   -   �� *SelectedSearchStartDate+  5t      :  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name �� 
IsReadOnly  BaseBorderBrush `� 	Converter �� Path �� RelativeSource �� AncestorType��%�  '        7  �� 5u      "  6$   .�5v   "   ��  � �� 5w   &   �� 5x   *   .R�5y   .   �� $ PART_TextBox��66    . $��0q�6^   $��Stretch=�6r   $��Stretch=�6�   #���  6�   .��6�   ��5z   2   `� 5{   6   8   .1�5|   :   �� $ SelectedDate�6B   �� 5}   :   $ 
DateFormat�6B   6V   �� 5~   :   $) #DataContext.SelectedSearchStartDate�6B    5   A   �� "  5�   7   .��5�   @   5�   /   5�   +   5�   #   5�      5�      5�        5�      -   5        $
��Left=�5�   I   $	��150��6d   $	��150��6s   $��	-60 0 5 5q�6�   $��1��5�   �   $��2��6�   {�5�   !   �� *EnableEndDropDown+   DisplayDateStart 5�   h   �� *EndDateValidation+ 6�   �� *SelectedSearchEndDate+  5�      ��%�  '        7  �� 5�      "  6$   .�5�   "   ��  � �� 5�   &   �� 5�   *   .R�5�   .   �� $ PART_TextBox��66    . $��0q�6^   $��Stretch=�6r   $��Stretch=�6�   #���  6�   .��6�   ��5�   2   `� 5�   6   8   .1�5�   :   �� $ SelectedDate�6B   �� 5�   :   $ 
DateFormat�6B   6V   �� 5�   :   $' !DataContext.SelectedSearchEndDate�6B    5�   A   �� "  5�   7   .��5�   @   5�   /   5�   +   5�   #   5�      5�      5�      5�      5�      ]� 5�      $��0��6   $��4��6)   $��0 0 0 0q�69   $��2��6J   $��2��6^   .+�5�      �� $!��Select a Start and End date��6    
�������$��Italic$�6U   6k   5�      5�      �� 5�      $ 
Horizontal=�6   $��0��62   $��3��6B   $��2��6O   $��	10 10 0 0q�6c   .+�5�      	� -   5        $ radProductsYes��5�      $��0 2 10 2q�68   $	 radShowBoth��6r   $��14��6�   $
��Left=�6�   ��6J   �� *ShowProductCommand+
 6�   �� *ShowProducts+$ Group1��$ PropertyChanged=�.��5�      ]� .+�5�      �� $��Products��6%   67   5�      5�      	� 5�      -	   5        $ radServicesYes��5�      $��5 2 10 2q�67   $	 radShowBoth��6r   $��15��6�   $
��Left=�6�   ��6I   �� *ShowServiceCommand+
 6�   �� *ShowServices+$ Group1��$ PropertyChanged=�.��5�      ]� .+�5�      �� $��Services��6%   67   5�      5�      	� 5�      -
   5        $ 	radShowNo��5�      $��5 2 10 2q�62   $	 radShowBoth��6n   $��15��6�   $
��Left=�6�   ��6D   �� *ShowBothTrueCommand+
 6�   �� *
ShowBoth+$ Group1��$ PropertyChanged=�.��5�      ]� .+�5�      �� $��Both ��6%   64   5�      5�      5�      �� 5�      $ 
Horizontal=�6   $��4��62   $��Center=�6B   $��3��6_   $��	60 10 0 0q�6l   .+�5�      	� -   5        $ radExcgstYes��5�      $��0 2 10 2q�6c   $	 radTax��6w   $��14��6�   $
��Left=�6�   ��64   �� *ShowExcludingTaxCommand+
 6�   �� *IncludingGSTFalse+$ Group1��$ PropertyChanged=�.��5�      ]� .+�5�      �� $��exc. ��6%   64   �� 5�      $��2,1,2,1q�6>   ��6%   �� *	TaxName+6Q   5�      5�      	� 5�      -   5        $ radIncgstyes��5�      $��5 2 10 2q�65   $	 radTax��6v   $��15��6�   $
��Left=�6�   ��6G   �� *ShowIncludingTaxCommand+
 6�   �� *IncludingGSTTrue+$ Group1��$ PropertyChanged=�.��5�      ]� .+�5�      �� $��inc. ��6%   64   �� 5�      $��2,1,2,1q�6>   ��6%   �� *	TaxName+6Q   5�      5�      5�      �� 5�      -   5        $��cmbCustomerNameSearch��5�   Y   
������ #��[ 5�   1   $��0��6e   $��4��6u    . $��	12 10 0 0q�6�   $
��Left=�6�   $��30��6�   $	��Top=�6�   $	��160��6�   $	��160��6�   $ CustomerName��5�      $ CustomerName��68   ��5�     �� *PandSSoldToCustomersListCus+ 5�      �� *SelectedCustomerName+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��0��6   $��4��6(   $��2��65   $��	17 15 0 0q�6I     WaterMarkStyle#��[ 6^   $
��Left=�5�      $��Search��62   #��[ 6@   y�5�      `� 5�      # [  6#   .1�5�      ��  �� ElementName$ cmbCustomerNameSearch��6"   $ Text.IsEmpty�6F   �� 5�      $ cmbCustomerNameSearch��6"   $ 	IsFocused�6F   5�      5�      �� 5�      $��4��6   $��0��6'   $��4��67   $��0,40,0,0q�6K   $	��998��6]   .+�5�      � .+�5�      &   System.Windows.Controls.DataGrid  -   5          Name$ CustomGridLines��5�      $��0��6`       GridLinesVisibility$	  All=�5�   P   !   HorizontalGridLinesBrush
! �����"   VerticalGridLinesBrush
" �����#   AutoGenerateColumns# .  $$   HorizontalScrollBarVisibility$$ Hidden=�5�      "%   VerticalScrollBarVisibility$% Disabled=�6C     BackHeaderStyle20&   ColumnHeaderStyle#& [ 5�      '   HeadersVisibility$	' All=�6R   $��0,0,0,0q�6j   ��5�   8   �� *BackGroundLines+��5�      �� $	 dg1��$ ActualHeight���6l   �� $	 dg1��$ ActualWidth�(   Columns( 5      0  *System.Windows.Controls.DataGridTextColumn  5     ,  &System.Windows.Controls.DataGridColumn)   Header$)  ��61   *   Width5  /System.Windows.Controls.DataGridLengthConverter$	* 162 6U   1	  +System.Windows.Controls.DataGridBoundColumn+ 	  Binding+ 6;   �� *Col0+6c     5     $)  ��61   $	* 160 6U   + 6;   �� *Col1+6c     5     $)  ��61   $	* 160 6U   + 6;   �� *Col4+6c     5     -   5        qtybackground��$)  ��5  H   $* 70 6l   + 6R   �� *Col4+6y     5     -   5        pricebackground��$)  ��5  J   $	* 130 6n   + 6T   �� *Col4+6|     5     -   5        amtbackground��$)  ��5  H   $	* 130 6l   + 6R   �� *Col4+6z     5     -   5        invoicenobackground��$)  ��5  N   $* 80 6r   + 6X   �� *Col2+6     5	     -   5        datebackground��$)  ��5	  I   $* 90 6m   + 6S   �� *Col3+6z   5       5     -   5        $	 dg1��5  �   $��5��6   $	��100��63    . $	  All=�6�   $��1q�6�   ,   CanUserAddRows, .  -   CanUserDeleteRows- .  .   CanUserResizeColumns. .   	 HeaderStyle20#& [	 5     $$ Disabled=�6K   
������ /   CanUserReorderColumns/ .  0   SelectionMode$0 Single=�6�   $	��Top=�6�   # .  ��5  C   �� * PandSSoldToCustomersGridHeight+��6�   �� *PandSSoldToCustomersList+( 5     4
  .System.Windows.Controls.DataGridTemplateColumn
  5     -   5        CustomerName��1   MinWidth$	1 162Q�5  K   2   MaxWidth$	2 162Q�6Z   $) Customer Name��6i   3   SortMemberPath$3 CustomerName��6�   4   HeaderTemplate4 5  "   �� 5  &   .R�5  *   �  5  .   �� 5  2   $
��auto �6C   �� 5  2   $��10 �6D   .+�5  .   �� #��z��68   �� 5  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5  1   $��20��6<   $
��Left=�5  ,   $��1��5  ,   5  +   5  '   5 
  CellTemplate5 5   "   �� 5!  &   .R�5"  *   �� $
��Left=�64   �� 5#  ,   6 �� Command6 66   �� *'%DataContext.NavigateToCustomerCommand+ �� " >�7 �� CommandParameter7 5$  2   �� *CustID+.�6V   .�5%  2   �� $
��Wrap=�6Z   $
��Left=�6n   ��6<   �� *CustomerName+6n   5&  .   5'  /   5(  '   5*     
  5+     -   5        	PandSCode��$	1 160Q�5+  H   $	2 160Q�6W   $) Product & Service Code��6f   $
* Auto 6�   $3 	PandSCode��6�   4 5,  "   �� 5-  &   .R�5.  *   �  5/  .   �� 50  2   $
��auto �6C   �� 51  2   $��10 �6D   .+�53  .   �� #��z��68   �� 54  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��55  1   $��20��6<   $
��Left=�56  ,   $��1��57  ,   59  +   5:  '   5 5<  "   �� 5=  &   .R�5>  *   �� �� 5?  ,   6 66   �� *&$DataContext.NavigateToProductCommand+ �� " >�7 5@  2   �� *	PandSCode+.�6Y   .�5A  2   �� ��6<   �� *	PandSCode+5B  .   5C  *   5D  '   5F     
  5G     -   5        	PandSName��$	1 160Q�5G  H   $	2 160Q�6W   $) Product & Service Name��6f   $3 	PandSName��6�   $
* Auto 6�   4 5H  "   �� 5I  &   .R�5J  *   �  5K  .   �� 5L  2   $
��auto �6C   �� 5M  2   $��10 �6D   .+�5O  .   �� #��z��68   �� 5P  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5Q  1   $��20��6<   $
��Left=�5R  ,   $��1��5S  ,   5T  +   5U  '   5 5W  "   �� 5X  &   .R�5Y  *   �� $
��Left=�64   �� 5Z  ,   6 66   �� *&$DataContext.NavigateToProductCommand+ �� " >�7 5[  2   �� *	PandSName+.�6Y   .�5\  2   �� ��6<   �� *	PandSName+5]  .   5^  *   5_  '   5a     
  5c     -   5        Quantity��$1 70Q�5c  G   $	) Qty��6V   $	3 Qty��6c    
 HeaderStyle20Right8   HeaderStyle#8 [
 6x   4 5d  "   �� 5e  &   .R�5f  *   �  5g  .   �� 5h  2   $
��auto �6C   �� 5i  2   $��10 �6D   .+�5k  .   �� #��z��68   �� 5l  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5m  1   $��20��6<   $
��Left=�5n  ,   $��1��5o  ,   5q  +   5r  '   5 5t  "   �� 5u  &   .R�5v  *   �� $��Right=�64   �� 5x  2   $
��Wrap=�6T   $��Right=�6h   ��6<   �� *QtyStr+6h   5z  /   5{  '   5}     
  5~     -   5        	Price��$	1 130Q�5~  D   $) Price��6T   $3 Price��6c   #8 [
 6z   4 5  "   �� 5�  &   .R�5�  *   �  5�  .   �� 5�  2   $
��auto �6C   �� 5�  2   $��10 �6D   .+�5�  .   �� #��z��68   �� 5�  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5�  1   $��20��6<   $
��Left=�5�  ,   $��1��5�  ,   5�  +   5�  '   5 5�  "   �� 5�  &   .R�5�  *   �� $��Right=�64   �� 5�  2   $
��Wrap=�6V   $��Right=�6j   ��6<   �� *
PriceStr+6j   5�  /   5�  '   5�     
  5�     -   5        
Amount��$	1 130Q�5�  E   $) Amount��6U   $3 Amount��6e   #8 [
 6}   4 5�  "   �� 5�  &   .R�5�  *   �  5�  .   �� 5�  2   $
��auto �6C   �� 5�  2   $��10 �6D   .+�5�  .   �� #��z��68   �� 5�  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5�  1   $��20��6<   $
��Left=�5�  ,   $��1��5�  ,   5�  +   5�  '   5 5�  "   �� 5�  &   .R�5�  *   �� $��Right=�64   �� 5�  2   $
��Wrap=�6W   $��Right=�6k   ��6<   �� *	AmountStr+6k   5�  /   5�  '   5�     
  5�     -   5        	InvoiceNo��$1 80Q�5�  H   $2 80Q�6V   $) 
Invoice No��6d   $3 	InvoiceNo��6x   #8 [
 6�   4 5�  "   �� 5�  &   .R�5�  *   �  5�  .   �� 5�  2   $
��auto �6C   �� 5�  2   $��10 �6D   .+�5�  .   �� $
��Wrap=�68   $��Right=�6L   
Invoice No5�  /   �� 5�  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5�  1   $��20��6<   $
��Left=�5�  ,   $��1��5�  ,   5�  +   5�  '   5 5�  "   �� 5�  &   .R�5�  *   �� $��Right=�64   �� 5�  ,   6 66   �� *#!DataContext.NavigaetoSalesCommand+ �� " >�7 5�  2   �� *	InvoiceNo+.�6Y   .�5�  2   �� $
��Wrap=�6W   $
��Left=�6k   ��6<   �� *	InvoiceNo+6k   5�  .   5�  /   5�  '   5�     
  5�     -   5        InvoiceDate��$1 90Q�5�  J   $2 90Q�6X   $) Invoice Date��6f   $3 InvoiceDate��6|   #8 [
 6�   4 5�  "   �� 5�  &   .R�5�  *   �  5�  .   �� 5�  2   $
��auto �6C   �� 5�  2   $��10 �6D   .+�5�  .   �� #��z��68   $��Right=�6Y   �� 5�  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5�  1   $��20��6<   $
��Left=�5�  ,   $��1��5�  ,   5�  +   5�  '   5 5�  "   �� 5�  &   .R�5�  *   �� $��Right=�64   �� 5�  2   $
��Wrap=�6Y   $
��Left=�6m   ��6<   �� *InvoiceDate+6m   5�  /   5�  '   5�     5�     5�     �� 5�     $ 
Horizontal=�6   $
��left=�67   $��0,1,0,0q�6R   $��20��6c   .+�5�     � ��6   �� $ 	PandSCode��$ ActualWidth�.+�5�     ��   BorderStyleLeft#��[ 6!   ._�5�     �� $��Total��6)   $
��Bold"�66   6J   5�     5�     � 5�     ��6   �� $ 	PandSName��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $�� ��6(   63   5�     5�     � 5�     ��6   �� $ CustomerName��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $�� ��6(   63   5      5     � 5     ��6   �� $ Quantity��$ ActualWidth�.+�5     �� #��[ 6!   ._�5     �� $�� ��6(   63   5     5     � 5     ��6   �� $ Price��$ ActualWidth�.+�5	     ��   BorderStyleRight#��[ 6!   ._�5
     �� $�� ��6(   63   5     5     � 5     ��6   �� $ Amount��$ ActualWidth�.+�5     �� #��[ 6!   ._�5     ��   DisplayTotalStyle#��[ 6u   ��6(   �� *TotalAmount+$ TwoWay=�$ PropertyChanged=�6�   5     5     � 5     ��6   �� $ 	InvoiceNo��$ ActualWidth�.+�5     �� #��[ 6!   ._�5     �� $�� ��6(   64   5     5     � 5     ��6   �� $ InvoiceDate��$ ActualWidth�.+�5     �� #��[ 6!   ._�5     �� $�� ��6(   64   5     5     5     5     �� 5      $��10 0 0 0q�6   $��5��6+   $��0��68   $��3��6H   $ 
Horizontal=�6\   $
��Left=�6u   $��Bottom=�6�   .+�5!     �� $��  Amounts are in  ��6   $��Italic$�67   
�������6^   �� 5"     $��Italic$�6:   
���������6   �� *CurrencyName+6a   5#     �� 5$     $ 
Horizontal=�6   $��3��64   $��5��6F   $��Right=�6S   $��10,0,0,0q�6p   $��Bottom=�6�   .+�5%     �� $��Close��6   $
��10 0q�6*     ButtonStyle#���  68   $	��New��6�   ��6^   �� $ CloseCommand�6�   5&     5'     5(     5)     
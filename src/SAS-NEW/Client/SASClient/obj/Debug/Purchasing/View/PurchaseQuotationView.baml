   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SDN.Purchasing.ViewSDN.Purchasing.View  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      O6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      /    )SDN.Purchasing.View.PurchaseQuotationView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:SDN.Purchasing.View     5      ;my,clr-namespace:SDN.Common;assembly=SDN.Common     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      $
��1024��5	      $
��auto��5        � 	Resources  5      ,  &SDN.Common.Converter.EmptyIntConverter   EmptyIntConverter,  &SDN.Common.Converter.DateTimeConverter  DateTimeFormatter.  (SDN.Common.Converter.RowToIndexConverter  RowToIndexConverter4  .SDN.Common.Converter.BoolToVisibilityConverter  	BoolToVis9  3SDN.Common.Converter.TextInputToVisibilityConverter " TextInputToVisibilityConverter  BorderStyle �� 
TargetType �� Property �� Value  TextBoxStyle  brushWatermarkBackground �� Color  brushWatermarkForeground 	 brushWatermarkBorder��%�  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 �     &	     &	 2    &		 P      5   
   6$     5   
   6@     5   
   6&     5   
   6,     5   
   61   �� 5   
   " ��6$   .�5      ��  � ��$ 1q�60   �� 5       � ��
 �   �6,   5      �� 5   
   " ��6%   .�5      ��  � ��$ 0q�60   5      �� 5   
   $ White��6;   �� 5   
   $
 Gray��6;   �� 5   
   $ Black��67   5      .��5      �� $
��Auto=�6   $
��Auto=�66   .��5    
   � $��
10,10,0,10q�6   $
��auto��6#   $
��auto��60     5!       
 
ComboStyle��%#  '��       &	
 �     �� 5"      " ��6   .�5#      ��  � ��$ 25��6/   6<   �� 5$       � ��$ 0,0,0,4q�6/   �� 5%       � ��
 �   �64   5&      �� 5'      " ��6+   .�5(      ��  � ��$ 0,0,0,4q�6/   �� 5)       � ��
 �   �64   5*      5+       � RowDefinitions 5,      �� 5-      $��33 �6    6.   �� 5.      $��33 �6    6.   �� 5/      $��1 �6    6-   �� 50      $��1 �6    6-   �� 51      $��25 �6    6.   �� 52      $
��Auto �6    60   �� 53      $��1 �6    6-   �� 54      $��1 �6    6-   �� 55      $��1 �6    6-   �� 56      $��39 �6    6.   �� 57      $��33 �6    6.   �� 58      $��33 �6    6.   �� 59      $��1 �6    6-   �� 5:      $��20 �6    6.   �� 5;      $��35 �6    6.    � ColumnDefinitions 5>      �� 5?      $	��250 �6#   61   �� 5@      $	��250 �6#   61   �� 5A      $	��160 �6#   61   �� 5B      $	��120 �6#   61   �� 5C      $	��220 �6#   61   .+�5F      ]� $��0��6   $��0��6%   $��2��65   .+�5G      �� -   5        $��lblSupplierName��5G      $��Supplier Name��64   6K   �� 5H      $��*��6   
���  ��$��50,0,0,0q�66   �� 5I      -   5        $��cmbSupplierName��5I   :   $��1��6    �� 
IsEditable . $��3,2,0,5q�6Q   $	��230��5J      $��25��6(   $
��Left=�65   #��[	 5K       �� DisplayMemberPath$ SupplierName��5M   I   	 �� SelectedValuePath$	 ID��6j   $	��Top=�6�   {�5I   b   �� *SupplierEnabled+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���6�   �� *LstSuppliers+ �� SelectedIndex 5L      �� *SelectedSupplierID+ �� 	Converter# [   �� SelectedValue 5M      �� *SelectedSupplierID+.  (System.Windows.Interactivity.Interaction   Triggers 5N      /  )System.Windows.Interactivity.EventTrigger  5O         	EventName$ SelectionChanged��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5P      6	  0System.Windows.Interactivity.InvokeCommandAction	   	  Command 64   �� *!SupplierSelectionChangedCommand+5Q      5S      �� 5T      $��10,0,0,0q�6   �� 5U       �� Command 6   �� *%#DataContext.NavigateToClientCommand+ �� RelativeSource ��  �� AncestorType" >� �� CommandParameter 5V      �� *SelectedSupplierID+.�6F   .�5W      �� $��Supplier Details��6"   $
��Wrap=�6:   5X      5Y      5Z      ]� 5[      $��0��6   $��0��6%   $��2��65   $��	130,0,0,0q�6I   .+�5\      �� $��17 5 0 0q�6     WaterMarkStyle#��[ 62   $
��Left=�5]      $��Search��62   #��[ 6@   y�5^      `� 5_       `� 	Converter# [ 6'   .1�5`      ��  �� ElementName$ cmbSupplierName��6&    �� Path$ Text.IsEmpty�6D   �� 5a      $ cmbSupplierName��6&   $ 	IsFocused�6D   5b      5d      5e      �� 5f      -   5        $��lblBlank��5f   5   $��0��6   $��2��6%   $�� ��6G   $��3��6O   6c   �� 5i      -   5        $��lblQuotationNo��5i   5   $��0��6   $��3��6%   $��Quotation No.��6K   6c   �� 5j      -   5        $��txtQuotationNo��5j   g   $��2��6   $
��Left=�6#   $	��210��6>   $��0��6J   $��4��6W   $��9,0,0,5q�6}    �� 
IsReadOnly . 
���������6�   �� *QuotationNo+$
 TwoWay=�$ PropertyChanged=�6  �� 5l      -   5        $��lblQuotationDate��5l   5   $��1��6   $��3��6%   $��Quotation Date��6M   6f   ]� 5m      $��1��6   $��4��6&   $
��Left=�67   .+�5n      �� $��*��6   
���  ��$��0,0,2,2q�66   6I   (
  "System.Windows.Controls.DatePicker
  5o      -   5        $��QuotationDatepicker��5p      $��4��5o      $	��210��6+   $��1,2,0,0q�67   $	��Top=�5p   �    
  SelectedDate 6.   �� *QuotationDateCalender+ �� BindingGroupName$ Group1��$ PropertyChanged=�  5q      :  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name  BaseBorderBrush��%�  '        7  �� 5r      "  6    .�5s      ��  � �� 5t   "   �� 5u   &   .R�5v   *   �� $ PART_TextBox��62    . $��0q�6[   $��Stretch=�6o   $��Stretch=�5w   .   $y�Hidden=�6Q   #���  6e   .��6�   ��5x   .   `� 5y   2   8   .1�5z   6   �� $ SelectedDate�6>   �� 5{   6   $ 
DateFormat�6>   6R   �� 5|   6   $' !DataContext.QuotationDateCalender�6>    5}   A   �� " 
 5~   3   .��5   <   5�   +   5�   '   5�      5�      5�      5�      �� 5�      -   5        $ PART_TextBox��5�   o   $��-258 -5 0 0q�6   $��21��6/   #��[	 6;    .  $��0q�6�   $��Stretch=�6�   $��Stretch=�5�      $	��160��6�   ��65   �� $ QuotationDateStr�$
 TwoWay=�$ PropertyChanged=�.��6�   5�      5�      ]� 5�      $��1��6   $��0��6%   $��2��65   .+�5�      �� -	   5        $��lblValidForDays��5�      $��Valid for (Days)��64   6O   �� 5�      -
   5        $��txtValidForDays��5�   P   $��3��6   $	��230��6'   $
��Left=�63   $��57,0,0,5q�6g    5�      �� *AllFieldsReadonly+$
 TwoWay=�$ PropertyChanged=���6n   �� *ValidForDays+$
 TwoWay=�$ PropertyChanged=�6�   5�      ]� 5�      $��4��6   $��4��6%   $��8,3,0,5q�65   $��Right=�6F   .+�5�      	� -   5        $��rdnExcludeGST��5�       	� 	GroupName$ grpTax��6�   {�63   �� *AllFieldsEnabled+$
 TwoWay=�$ PropertyChanged=� d� 	IsChecked 6�   �� *ExcludingTax+$
 TwoWay=�$ PropertyChanged=� 5�        5�      $ Checked��6)   . 5�      	    	  CommandParameter$
  SSRT��6a    64   �� *ExcludeTaxCheckedCommand+6a   5�      5�      �� 5�      -   5        $��lblExcludeGST��5�      $��	10,0,10,0q�62   �� 5�      $
�exc.��6    �� 5�      �6   �� *	TaxName+5�      	� 5�      -   5        $��rdnIncludeGST��5�      $ grpTax��6�   {�64   �� *AllFieldsEnabled+$
 TwoWay=�$ PropertyChanged=� 6�   �� *IncludingTax+$
 TwoWay=�$ PropertyChanged=� 5�        5�      $ Checked��6)   . 5�      	  $
  SSRT��6a    64   �� *IncludeTaxCheckedCommand+6a   5�      5�      �� 5�      -   5        $��lblIncludeGST��5�      $��10,0,0,0q�62   �� 5�      $
�inc.��6    �� 5�      �6   �� *	TaxName+5�      5�      � 5�      $	��998��6   $��5��6E   $��0��6R   $��5��6b   $	��300��6v   ��6    �� *PQFormGridHeight+.+�5�      � .+�5�      &   System.Windows.Controls.DataGrid  -   5        !  Name$! CustomGridLines��5�      $��0��6`   "   GridLinesVisibility$	" All=�5�   U   #   HorizontalGridLinesBrush
# �����$   VerticalGridLinesBrush
$ �����%   AutoGenerateColumns% .  $&   HorizontalScrollBarVisibility$& Hidden=�5�      "'   VerticalScrollBarVisibility$' Disabled=�6C     BackHeaderStyle20(   ColumnHeaderStyle#( [ 5�      )   HeadersVisibility$	) All=�6R   $��0,0,0,0q�6j   ��5�   8   �� *BackGroundLines+��5�      �� $ grdPandS��$ ActualHeight���6q   �� $ grdPandS��$ ActualWidth�*   Columns* 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn+   Header$+  ��61   ,   Width5  /System.Windows.Controls.DataGridLengthConverter$	, 230 6U   1  +System.Windows.Controls.DataGridBoundColumn-   Binding- 6;   �� *Col1+6c     5�      $+  ��61   $	, 230 6U   - 6;   �� *Col2+6c     5�      $+  ��61   $	, 110 6U   - 6;   �� *Col3+6c     5�      $+  ��61   $	, 120 6U   - 6;   �� *Col4+6c     5�      $+  ��61   $, 60 6U   - 6;   �� *Col5+6b     5�      $+  ��61   $	, 145 6U   - 6;   �� *Col6+6c     5�      $+  ��61   $, 88 6U   - 6;   �� *Col7+6b   5�        5�      -   5        $��grdPandS��5�   Z   $��8��6   $
��Left=�63   $	��998��6N   $	" All=�6j   $��1q�5�      
���   �% .  .   CanUserAddRows. . $��Disabled=�5�   O   /   CanUserReorderColumns/ .  0   CanUserSortColumns0 . 1   CanUserDeleteRows1 . 
������ $
��Auto=�5�      ��.    HeaderStyle20#( [ 5�       2   
IsReadOnly2 5�   �   �� *AllFieldsReadonly+$
 TwoWay=�$ PropertyChanged=���5�   ?   �� *PQFormGridHeight+* 5�      4  .System.Windows.Controls.DataGridComboBoxColumn  5�      $	, 230 66   -   5        
PSCode��3   SortMemberPath$3 PSCode��5�   R   4   DisplayMemberPath$4 PSCode��5�      5   SelectedValuePath$5 ID��5�      6   SelectedValueBinding6 5�      �� *SelectedPSID+$
 TwoWay=�$ PropertyChanged=�7   HeaderTemplate7 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   6B    5�   .   �� 5�   2   ��6C   �� $ PSCode��$ ActualWidth�.+�5�   .   ]� $��0��68   $��0��6E   .+�5�   2   �� $��txtHeaderPandScode��6<   �� 5�   "   $�Product & Service Code��6&   6J   5�   3   �� 5�   2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�   1   $��20��6<   $
��Left=�5�   ,   �� 5�   2   $��*��6<   
���  ��6X   5�   /   5�   +   5�   '   8   ElementStyle8 5�   "   �� 5�   &   " ��6,   .�5�   *   ��  � �� 6H   �� $$ DataContext.ProductAndServices� �� "  5  '   9   EditingElementStyle9 5  "   �� 5  &   " ��6,   .�5  *   ��  � �� 6H   �� $$ DataContext.ProductAndServices� �� "  �� 5  *    �@��
IsEditable . 6G   -   5        5	  '   5       5     $	, 230 65   -   5        	chkPSName��$4 PSName��5     $3 PSName��61   $5 ID��5     6 5     �� *SelectedPSID+$
 TwoWay=�$ PropertyChanged=�7 5  "   �� 5  &   .R�5  *   �  5  .   �� 5  2   6B    5  .   �� 5  2   ��6C   �� $ 	chkPSName��$ ActualWidth�.+�5  .   ]� $��0��68   $��0��6E   .+�5  2   �� $��txtHeaderPandSname��6<   �� 5  "   $�Product & Service Name��6&   6J   5  3   �� 5   2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5!  1   $��20��6<   $
��Left=�5"  ,   �� 5#  2   $��*��6<   
���  ��6X   5$  /   5&  +   5'  '   8 5*  "   �� 5+  &   " ��6,   .�5,  *   ��  � �� 6H   �� $$ DataContext.ProductAndServices� �� "  5.  '   9 50  "   �� 51  &   " ��6,   .�52  *   ��  � �� 6H   �� $$ DataContext.ProductAndServices� �� "  �� 53  *    �@��
IsEditable . 6G   55  '   5<       5>     -   5        
txtQty��$3 PQQty��5>  A   $	, 110 6�     HeaderStyle20Right:   HeaderStyle#: [ 6�   - 6X   �� *PQQty+$
 TwoWay=�$ 	LostFocus=�7 5?  "   �� 5@  &   .R�5A  *   �  5B  .   �� 5C  2   6B    5E  .   �� 5F  2   ��6C   �� $ txtQty��$ ActualWidth�.+�5H  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5I  2   �� �� 5J  #   $�Quantity��6'   6:   �� 5K  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5L  1   $��20��6<   $
��Left=�5M  ,   �� 5N  2   $��*��6<   
���  ��6X   5P  /   5Q  +   5R  '   ;   ElementStyle; 5V  "   �� 5W  &   " ��6,   .�5X  *   ��  � ��$ Right=�6P   5Y  '   <   EditingElementStyle< 5[  "   �� 5\  &   " ��6,   .�5]  *   ��  �@��	MaxLength$ 5��6F   �� 5^  *    � ��$ Right=�6W   -   5        5a  '   5c       5d     -   5        Txtprice��$3 PQPrice��5d  D   $	, 120 6�   #: [ 6�   - 6_   �� *	PQPrice+= �� StringFormat$= 
{0:0.####}��$
 TwoWay=�$ 	LostFocus=�7 5e  "   �� 5f  &   .R�5g  *   �  5h  .   �� 5i  2   6B    5k  .   �� 5l  2   ��6C   �� $ Txtprice��$ ActualWidth�.+�5n  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5o  2   �� �� 5p  #   $�Price��6'   67   �� 5q  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5r  1   $��20��6<   $
��Left=�5s  ,   5t  /   5u  +   5v  '   ; 5x  "   �� 5y  &   " ��6,   .�5z  *   ��  � ��$ Right=�6P   5{  '   < 5}  "   �� 5~  &   " ��6,   .�5  *   ��  �@��	MaxLength$ 10��6F   �� 5�  *    � ��$ Right=�6W   -   5        5�  '   5�       5�     -   5        Txtdiscount��>   CanUserSort> .  $+ Disc %��5�     $, 60 6y   #: [ 6�   ?   SortDirection? 5�  F   Z� - 5�  +   �� *
PQDiscount+$
 TwoWay=�$ 	LostFocus=�; 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   5�  '   < 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  �@��	MaxLength$ 2��6F   �� 5�  *    � ��$ Right=�6W   5�  '   5�       5�     -   5        	Txtamount��$3 PQAmountStr��5�  D   $+ Amount��6b   $	, 145 6�   @   
IsReadOnly@ . #: [ 6�   - 6t   �� *PQAmountStr+7 5�  "   �� 5�  &   .R�5�  *   �  5�  .   �� 5�  2   6B    5�  .   �� 5�  2   ��6C   �� $ 	Txtamount��$ ActualWidth�.+�5�  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5�  2   �� �� 5�  #   $�Amount��6'   68   �� 5�  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�  1   $��20��6<   $
��Left=�5�  ,   5�  /   5�  +   5�  '   ; 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   5�  '   5�       5�     -   5        
TxtTaxname��$+ 
Tax Rate %��5�  *   > .  $, 88 5�  )   @ . #: [ 6F   ? 5�  >   Z� - 5�  )   �� *
GSTRateStr+$
 TwoWay=�$ PropertyChanged=�7 5�  "   �� 5�  &   .R�5�  *   � A � IsSharedSizeScopeA . ��6O   �� $ 
TxtTaxname��$ ActualWidth� 5�  .   �� 5�  2   6F   .+�5�  .   �� $��0��68   $��Right=�6H   �� 5�  2   �66   �� *DataContext.TaxName+ �� " >�6�    �� 5�  2   $�Rate %��67   6G   5�  /   5�  +   5�  '   ; 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   5�  '   5�     5�     5�     5�     �� 5�     $��185,23,0,25q�6   $	��250��6.   $��Center=�5�     $��10��6;   $��1��6I   $��2��6Y   
���  ��B J� RenderTransformOrigin$B 0.668,0.529&�6�   $��2��6�   $��25��6  $
��Bold"�6  y�6j   �� $ RubberStampPO�# [ 	CONVERTED6.  �� 5�     $��185,10,0,25q�6   $	��250��6-   $��Center=�5�     $��10��6;   $��1��6I   $��2��6Y   
���  ��$B 0.669,0.530&�6�   $��2��6�   $��25��6  $
��Bold"�6  y�6j   �� $ RubberStampPI�# [ 	CONVERTED6-  �� 5�     -   5        $��lblTotalBeforeTax��5�  I   $��9��6   $��2��6%   $��2��65   $��Total before Tax��6b   $��	90 10 0 0q�6z   $��Center=�5�     66   �� 5�     -   5        $��txtTotalBeforeTax��5�  [   $��9��6   $��3��6$   $��2��64   $��	91,10,0,4q�6H    . $
��Left=�6�   $��Right=�5�     
���������5�  �   �� $ 	Txtamount��$ ActualWidth���5�  I   �� *TotalBeforeTaxStr+$
 TwoWay=�$ PropertyChanged=�6�   �� 5�     -   5        $��lblTax��5�  J   $��10��6   $��2��6&   $��2��66   $��	100,0,0,0q�6q   $��Center=�5�     ��5�  X   �� *	TaxName+5�  5   �� 5�     -   5        $��txtTax��5�  Z   $��10��6   $��3��6$   $��2��64   $��91,0,0,4q�6H    . 
�������$
��Left=�6�   $��Right=�5�     ��5�  �   �� $ 	Txtamount��$ ActualWidth���5�  7   �� *TotalTaxStr+$
 TwoWay=�$ PropertyChanged=�6�   �� 5�     -   5        $��lblTotalAfterTax��5�  L   $��11��6   $��2��6'   $��2��68   $��90,0,0,0q�6d   $��Center=�6v   �� 5�     $�Total after Tax��6    �� 5�     �6   �� *CurrencyName+5�     �� 5�     -    5        $��txtTotalAfterTax��5�  Z   $��11��6   $��3��6$   $��2��64   $��91,0,0,0q�6H    . 
�������$
��Left=�6�   $��Right=�5�     ��5�  �   �� $ 	Txtamount��$ ActualWidth���5�  3   �� *TotalAfterTaxStr+$
 TwoWay=�$ PropertyChanged=�6�   �� 5�     -!   5        $��lblTermsandConditions��5�  K   $��9��6   $��2��6&   $��0��6:   $��0 10 0 0q�6h   $��Terms and Conditions��6z   6�   �� 5�     -"   5        $ txtTermsandConditions��5�  #   $��5��6   $��10��6B   $��0��6P   $��4��6`   $��2��6q   $	��370��6�   C �� TextWrapping$
C Wrap=�5�  o   $
��Left=�6�   $��80��6�   $	��Top=�6�    6   �� *AllFieldsReadonly+$
 TwoWay=�$ PropertyChanged=���5�     �� *TermsAndConditions+$
 TwoWay=�$ PropertyChanged=�6f   �� 5     $��13��6   $��0��6&   $��20��66   �� 5     $��13��6   $��3��6&   $��3��66   $��3��6J   
���  ��$
��Wrap=�6p   ��6�   �� *
PQErrors+$
 TwoWay=�$ PropertyChanged=�6�   ]� 5     $��14��6   $��0��6&   $
��Left=�67   $��Bottom=�6R   $��2��6n   $��	0 10 10 0q�6�   .+�5     �� $��6��6   $��Convert to Purchase Order��6&     ButtonStyle#��[ 6K   $	��180��6p   $
��Left=�6|   ��6�   �� *ConvertToPOCommand+6�   �� 5     $��7��6   $!��Convert to Purchase Invoice��6&   #��[ 6M   $	��180��6r   $��10,0,0,0q�6~   $
��Left=�6�   ��6�   �� *ConvertToPICommand+6�   5     �� 5     
���  ��$��20��6+   $��3,0,0,0q�67   $	��500��6H   $
��Wrap=�6T   $��3��6�   $��13��6�   $��2��6�   ��6h   �� $ 
DateErrors�$
 TwoWay=�$ PropertyChanged=�6�   ]� 5     $��14��6   $��2��6&   $��Right=�66   $��Bottom=�6R   $��3��6m   $��0 0 3 0q�6�   .+�5     �� -#   5        D ��Name$D btnPrint��5  &   $��9��6   $��10,0,0,0q�68   $��Print��6J   #���  6�   ��6Z   �� *clickCommand+$
 TwoWay=���6�   �� $ QuotationNo�6�   �� 5     -$   5        $D btnDuplicate��5  '   $��10��6   $��	Duplicate��6=   $��10,0,0,0q�6Q   #���  6c   ��6�   �� *DuplicateCommand+6�   �� 5     -%   5        $D 	btnDelete��5  '   $��11��6   $��Delete��6:   $��10,0,0,0q�6K   #���  6]   ��6�   �� *DeleteCommand+6�   �� 5     -&   5        $D btnNew��5  '   $��12��6   $	��New��67   $��10,0,0,0q�6E   #���  6W   $	��New��6�   ��6}   �� *NewPQCommand+6�   �� 5     -'   5        $D btnSave��5  '   $��13��6   $
��Save��68   $��10,0,0,0q�6G   #���  6Y   ��6   �� *SaveCommand+6�   �� 5     -(   5        $D btnClose��5  '   $��14��6   $��Close��69   $��10,0,0,0q�6I   #���  6[   ��6�   �� *CloseCommand+6�   5     5     5      5!     
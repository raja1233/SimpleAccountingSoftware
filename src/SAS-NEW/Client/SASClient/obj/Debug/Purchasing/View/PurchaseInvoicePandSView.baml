   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SDN.Purchasing.ViewSDN.Purchasing.View  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      O6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5
      2    ,SDN.Purchasing.View.PurchaseInvoicePandSView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:SDN.Purchasing.View     5      ;my,clr-namespace:SDN.Common;assembly=SDN.Common     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5	      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5
      $
��1024��5         � 	Resources  5      ,  &SDN.Common.Converter.EmptyIntConverter   EmptyIntConverter,  &SDN.Common.Converter.DateTimeConverter  DateTimeFormatter.  (SDN.Common.Converter.RowToIndexConverter  RowToIndexConverter9  3SDN.Common.Converter.TextInputToVisibilityConverter " TextInputToVisibilityConverter  BorderStyle �� 
TargetType �� Property �� Value  TextBoxStyle  brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder��%�  &	        &	      &	 &     &	 9     &	 L     &	 �     &	      &	     &	 =      5   
   6$     5   
   6@     5   
   6&     5   
   61   �� 5   
   " ��6$   .�5      ��  � ��$ 1q�60   �� 5       � ��
 �   �6,   5      �� 5   
   " ��6%   .�5      ��  � ��$ 0q�60   5      �� 5   
   $ White��6;   �� 5   
   $
 Gray��6;   �� 5   
   $ Black��67   5      .��5      �� $
��Auto=�6   $
��Auto=�66   .��5    
   � $��
10,10,0,10q�6   $
��auto��6#   $
��auto��60     5!       	 
ComboStyle��%#  '��       &		 �     �� 5"      " ��6   .�5#      ��  � ��$ 25��6/   6<   �� 5$       � ��$ 0,0,0,4q�6/   �� 5%       � ��
 �   �64   5&      �� 5'      " ��6+   .�5(      ��  � ��$ 0,0,0,4q�6/   �� 5)       � ��
 �   �64   5*      5+       � RowDefinitions 5,      �� 5-      $��33 �6    6.   �� 5.      $��33 �6    6.   �� 5/      $��33 �6    6.   �� 50      $��25 �6    6.   �� 52      $
��Auto �6    60   �� 53      $��39 �6    6.   �� 54      $��33 �6    6.   �� 55      $��33 �6    6.   �� 56      $��20 �6    6.   �� 57      $��35 �6    6.    � ColumnDefinitions 5>      �� 5?      $	��250 �6#   61   �� 5@      $	��250 �6#   61   �� 5A      $	��160 �6#   61   �� 5B      $	��120 �6#   61   �� 5C      $	��220 �6#   61   .+�5F      ]� $��0��6   $��0��6%   $��2��65   .+�5G      �� -   5        $��lblSupplierName��5G      $��Supplier Name��64   6K   �� 5H      $��*��6   
���  ��$��50,0,0,0q�66   �� 5I      -   5        $��cmbSupplierName��5I   :   $��1��6    �� 
IsEditable . $��3,2,0,5q�6Q   $	��230��5J      $��25��6(   $
��Left=�65   #��[ 5K       �� DisplayMemberPath$ SupplierName��5M   I   	 �� SelectedValuePath$	 ID��6j   $	��Top=�6�   {�5I   b   �� *SupplierEnabled+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���6�   �� *LstSuppliers+ �� SelectedIndex 5L      �� *SelectedSupplierID+ �� 	Converter# [   �� SelectedValue 5M      �� *SelectedSupplierID+.  (System.Windows.Interactivity.Interaction   Triggers 5N      /  )System.Windows.Interactivity.EventTrigger  5O         	EventName$ SelectionChanged��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5P      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� *!SupplierSelectionChangedCommand+5Q      5S      �� 5T      $��10,0,0,0q�6   �� 5U       �� Command 6   �� *%#DataContext.NavigateToClientCommand+ �� RelativeSource ��  �� AncestorType" >� �� CommandParameter 5V      �� *SelectedSupplierID+.�6F   .�5W      �� $��Supplier Details��6"   $
��Wrap=�6:   5X      5Y      5Z      ]� 5[      $��0��6   $��0��6%   $��2��65   $��	130,0,0,0q�6I   .+�5\      �� $��17 5 0 0q�6    
 WaterMarkStyle#��[
 62   $
��Left=�5]      $��Search��62   #��[ 6@   y�5^      `� 5_       `� 	Converter# [ 6'   .1�5`      ��  �� ElementName$ cmbSupplierName��6&    �� Path$ Text.IsEmpty�6D   �� 5a      $ cmbSupplierName��6&   $ 	IsFocused�6D   5b      5d      5e      �� 5f      -   5        $��lblBlank��5f   5   $��0��6   $��2��6%   $�� ��6G   $��3��6O   6c   �� 5i      -   5        $��lblInvoiceNo��5i   5   $��0��6   $��3��6%   $��Invoice No.��6I   6_   �� 5j      -   5        $��txtInvoiceNo��5j   g   $��2��6   $
��Left=�6#   $	��211��6>   $��0��6J   $��4��6W    �� 	MaxLength$ 50��5k      $��8,0,0,5q�6"   ��63   �� *	InvoiceNo+$
 TwoWay=�$ PropertyChanged=�6�   �� 5m      -   5        $��lblInvoiceDate��5m   5   $��1��6   $��3��6%   $��Invoice Date��6K   6b   ]� 5n      $��1��6   $��4��6&   $
��Left=�67   .+�5o      �� $��*��6   
���  ��$��0,0,2,2q�66   6I   (	  "System.Windows.Controls.DatePicker	  5p      -   5        $��InvoiceDatepicker��5q      $��4��5p      $	��211��6*   $��1,0,1,4q�67    	  SelectedDate 5q   -   �� *InvoiceDateCalender+ �� BindingGroupName$ Group1��$ PropertyChanged=�  5r      :
  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name �� 
IsReadOnly  BaseBorderBrush��%�  '
        7  �� 5s      " 
 6    .�5t      ��  � �� 5u   "   �� 5v   &   .R�5w   *   �� $ PART_TextBox��62    . $��0q�6[   $��Stretch=�6o   $��Stretch=�5x   .   $y�Hidden=�6R   #���  6f   .��6�   ��5y   .   `� 5z   2   8   .1�5{   6   �� $ SelectedDate�6>   �� 5|   6   $ 
DateFormat�6>   6R   �� 5}   6   $% DataContext.InvoiceDateCalender�6>    5~   A   �� " 	 5   3   .��5�   <   5�   +   5�   '   5�      5�      5�      5�      �� 5�      -   5        $ PART_TextBox1��5�   o   $��-262 -5 0 0q�6   $��21��6/   #��[ 6;    .  $��0q�6�   $��Stretch=�6�   $��Stretch=�5�      $	��160��6�   ��65   �� $ InvoiceDateStr�$
 TwoWay=�$ PropertyChanged=�.��6�   5�      5�      ]� 5�      $��1��6   $��0��6%   $��2��65   .+�5�      �� -	   5        $��
lblOurPONo��5�      $��
Our PO No.��6/   6D   �� 5�      -
   5        $��
txtOurPONo��5�   a   $��3��6   $	��230��6'   $
��Left=�63    . $��77,0,0,5q�6s   ��5�      �� *	OurPONo+$
 TwoWay=�$ PropertyChanged=�6_   �� 5�      $��Balance��6   $
��Left=�6,   $��11,0,0,0q�6G   6[   5�      ]� 5�      $��2��6   $��0��6%   $��2��65   .+�5�      �� $��Credit Limit Amount��6   $��Right=�68   $��0,0,1,0q�6T   6g   5�      �� 5�      $��1��6   $��2��6%   $��10,0,0,0q�65   $
��Left=�6d   ��6G   �� *Sup_Balance+6�   �� 5�      $��2��6   $��2��6%   $��10,0,0,0q�65   $
��Left=�6n   ��6G   �� *Sup_CreditLimitAmount+6�   �� 5�      -   5        $��lblPaymentDueDate��5�   5   $��2��6   $��3��6%   $��Payment Due Date��6N   6i   ]� 5�      $��2��6   $��4��6&   $
��Left=�67   .+�5�      �� $��*��6   
���  ��$��0,0,2,2q�66   6I   	  5�      -   5        $��PayDueDatepicker��5�      $��6��5�      $	��211��6*   $��1,0,1,4q�67    5�   -   �� *PayDueDateCalender+$ Group1��$ PropertyChanged=�  5�      ��%�  '
        7  �� 5�      " 
 6    .�5�      ��  � �� 5�   "   �� 5�   &   .R�5�   *   �� $ PART_TextBox��62    . $��0q�6[   $��Stretch=�6o   $��Stretch=�5�   .   $y�Hidden=�6Q   #���  6e   .��6�   ��5�   .   `� 5�   2   8   .1�5�   6   �� $ SelectedDate�6>   �� 5�   6   $ 
DateFormat�6>   6R   �� 5�   6   $$ DataContext.PayDueDateCalender�6>    5�   A   �� " 	 5�   3   .��5�   <   5�   +   5�   '   5�      5�      5�      5�      �� 5�      -   5        $ PART_TextBox��5�   o   $��-262 -5 0 0q�6   $��21��6/   #��[ 6;    .  $��0q�6�   $��Stretch=�6�   $��Stretch=�5�      $	��160��6�   ��65   �� $ PaymentDueDateStr�$
 TwoWay=�$ PropertyChanged=�.��6�   5�      5�      �� 5�      $��5��6   $��2��6"   $
��Left=�6/   $��0��6J   $	��150��6Z   $��Enter Business Expenses��5�   8     ButtonStyle#��[ 6Z   ��6   �� *NavigateToBECommand+6�   �� 5�      $��3��6   $��0��6%   $��6��65   
�������$��Italic$�6[   �If you returned P&S to Supplier, enter minus quantity. If Total has minus value, Simple will automatically create a Debit Note.5�      ]� 5�      $��3��6   $��4��6%   $��8,3,0,5q�65   $��Right=�6F   .+�5�      	� -   5        $��rdnExcludeGST��5�       	� 	GroupName$ grpTax��6�   {�63   �� *AllFieldsEnabled+$
 TwoWay=�$ PropertyChanged=�  d� 	IsChecked  6�   �� *ExcludingTax+$
 TwoWay=�$ PropertyChanged=� 5�        5�      $ Checked��6)   . 5�        !   CommandParameter$
! SSRT��6a    64   �� *ExcludeTaxCheckedCommand+6a   5�      5�      �� 5�      -   5        $��lblExcludeGST��5�      $��	10,0,10,0q�62   �� 5�      $
�exc.��6    �� 5�      �6   �� *	TaxName+5�      	� 5�      -   5        $��rdnIncludeGST��5�      $ grpTax��6�   {�64   �� *AllFieldsEnabled+$
 TwoWay=�$ PropertyChanged=�  6�   �� *IncludingTax+$
 TwoWay=�$ PropertyChanged=� 5�        5�      $ Checked��6)   . 5�        $
! SSRT��6a    64   �� *IncludeTaxCheckedCommand+6a   5�      5�      �� 5�      -   5        $��lblIncludeGST��5�      $��10,0,0,0q�62   �� 5�      $
�inc.��6    �� 5�      �6   �� *	TaxName+5�      5�      � 5�      $	��998��6   $��4��6E   $��0��6R   $��6��6b   ��6    �� *PIFormGridHeight+.+�5�      � .+�5�      &   System.Windows.Controls.DataGrid  -   5        "  Name$" CustomGridLines��5�      $��0��6`   #   GridLinesVisibility$	# All=�5�   U   $   HorizontalGridLinesBrush
$ �����%   VerticalGridLinesBrush
% �����&   AutoGenerateColumns& .  '   CanUserSortColumns' .  $(   HorizontalScrollBarVisibility$( Hidden=�5�      ")   VerticalScrollBarVisibility$) Disabled=�6C     BackHeaderStyle20*   ColumnHeaderStyle#* [ 5�      +   HeadersVisibility$	+ All=�6R   $��0,0,0,0q�6j   ��5�   8   �� *BackGroundLines+��5�      �� $ grdPandS��$ ActualHeight���6q   �� $ grdPandS��$ ActualWidth�,   Columns, 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn-   Header$-  ��61   .   Width5  /System.Windows.Controls.DataGridLengthConverter$	. 230 6U   1  +System.Windows.Controls.DataGridBoundColumn/   Binding/ 6;   �� *Col0+6c     5�      $-  ��61   $	. 230 6U   / 6;   �� *Col1+6c     5�      $-  ��61   $	. 110 6U   / 6;   �� *Col2+6c     5      $-  ��61   $	. 120 6U   / 6;   �� *Col3+6c     5     $-  ��61   $. 60 6U   / 6;   �� *Col4+6b     5     $-  ��61   $	. 145 6U   / 6;   �� *Col4+6c     5     $-  ��61   $. 88 6U   / 6;   �� *Col4+6b   5       5     -   5        $��grdPandS��5  Z   $��8��6   $
��Left=�63   $	��998��6N   $	# All=�6j   $��1q�5     
���   �& .  0   CanUserAddRows0 . $��Disabled=�5	  O   1   CanUserReorderColumns1 .  ' . 2   CanUserDeleteRows2 . 
������ $
��Auto=�5     ��.    HeaderStyle20#* [ 5     3   
IsReadOnly3 5  �   �� *AllFieldsReadonly+$
 TwoWay=�$ PropertyChanged=���5  @   �� *PIFormGridHeight+, 5     4  .System.Windows.Controls.DataGridComboBoxColumn  5     $	. 230 66   -   5        	chkPSCode��4   DisplayMemberPath$4 PSCode��5     5   SelectedValuePath$5 ID��5     6   SelectedValueBinding6 5     �� *SelectedPSID+$
 TwoWay=�$ PropertyChanged=�7   HeaderTemplate7 5  "   �� 5  &   .R�5  *   �  5  .   �� 5  2   6B    5  .   �� 5  2   ��6C   �� $ 	chkPSCode��$ ActualWidth�.+�5!  .   ]� $��0��68   $��0��6E   .+�5"  2   �� $��txtHeaderPandScode��6<   �� 5#  "   $�Product & Service Code��6&   6J   5$  3   �� 5%  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5&  1   $��20��6<   $
��Left=�5'  ,   �� 5(  2   $��*��6<   
���  ��6X   5)  /   5+  +   5,  '   8   ElementStyle8 5.  "   �� 5/  &   " ��6,   .�50  *   ��  � �� 6H   �� $$ DataContext.ProductAndServices� �� "  52  '   9   EditingElementStyle9 54  "   �� 55  &   " ��6,   .�56  *   ��  � �� 6H   �� $$ DataContext.ProductAndServices� �� "  �� 57  *    �@��
IsEditable . 6G   -   5        5<  '   5@       5B     $	. 230 65   -   5        	chkPSName��$4 PSName��5C     $5 ID��5D     6 5E     �� *SelectedPSID+$
 TwoWay=�$ PropertyChanged=�7 5F  "   �� 5G  &   .R�5H  *   �  5I  .   �� 5J  2   6B    5L  .   �� 5M  2   ��6C   �� $ 	chkPSName��$ ActualWidth�.+�5O  .   ]� $��0��68   $��0��6E   .+�5P  2   �� $��txtHeaderPandSname��6<   �� 5Q  "   $�Product & Service Name��6&   6J   5R  3   �� 5S  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5T  1   $��20��6<   $
��Left=�5U  ,   �� 5V  2   $��*��6<   
���  ��6X   5W  /   5Y  +   5Z  '   8 5\  "   �� 5]  &   " ��6,   .�5^  *   ��  � �� 6H   �� $$ DataContext.ProductAndServices� �� "  5`  '   9 5b  "   �� 5c  &   " ��6,   .�5d  *   ��  � �� 6H   �� $$ DataContext.ProductAndServices� �� "  �� 5e  *    �@��
IsEditable . 6G   5g  '   5n       5p     -   5        
txtQty��:   SortMemberPath$: PQQty��5p  B   $	. 110 6�     HeaderStyle20Right;   HeaderStyle#; [ 6�   / 6Y   �� *PQQty+$
 TwoWay=�$ 	LostFocus=�7 5q  "   �� 5r  &   .R�5s  *   �  5t  .   �� 5u  2   6B    5w  .   �� 5x  2   ��6C   �� $ txtQty��$ ActualWidth�.+�5z  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5{  2   �� �� 5|  #   $�Quantity��6'   6:   �� 5}  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5~  1   $��20��6<   $
��Left=�5  ,   �� 5�  2   $��*��6<   
���  ��6X   5�  /   5�  +   5�  '   <   ElementStyle< 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   5�  '   =   EditingElementStyle= 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  �@��	MaxLength$ 5��6F   �� 5�  *    � ��$ Right=�6W   5�  '   5�       5�     #; [ 61   -   5        Txtprice��$: PQPrice��5�  v   $- Price��6�   $	. 120 6  / 6�   �� *	PQPrice+> �� StringFormat$> 
{0:0.####}��$
 TwoWay=�$ 	LostFocus=�7 5�  "   �� 5�  &   .R�5�  *   �  5�  .   �� 5�  2   6B    5�  .   �� 5�  2   ��6C   �� $ Txtprice��$ ActualWidth�.+�5�  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5�  2   �� �� 5�  #   $�Price��6'   67   �� 5�  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�  1   $��20��6<   $
��Left=�5�  ,   5�  /   5�  +   5�  '   < 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   5�  '   = 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  �@��	MaxLength$ 10��6F   �� 5�  *    � ��$ Right=�6W   5�  '   5�       5�     -   5        Txtdiscount��?   CanUserSort? .  #; [ 5�  s   $- Disc %��5�     $. 60 6y   @   SortDirection@ 5�  F   Z� / 5�  +   �� *
PQDiscount+$
 TwoWay=�$ 	LostFocus=�< 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   5�  '   = 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  �@��	MaxLength$ 2��6F   �� 5�  *    � ��$ Right=�6W   5�  '   5�       5�     #; [ 61   -   5        	Txtamount��$: PQAmountStr��5�  v   $- Amount��6�   $	. 145 6�   A   
IsReadOnlyA . / 6�   �� *PQAmountStr+7 5�  "   �� 5�  &   .R�5�  *   �  5�  .   �� 5�  2   6B    5�  .   �� 5�  2   ��6C   �� $ 	Txtamount��$ ActualWidth�.+�5�  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5�  2   �� �� 5�  #   $�Amount��6'   68   �� 5�  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�  1   $��20��6<   $
��Left=�5�  ,   5�  /   5�  +   5�  '   < 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   5�  '   5�       5�     -   5        
TxtTaxname��#; [ 5�  F   $- 
Tax Rate %��5�  *   ? .  $. 88 5�  )   A . @ 5�  >   Z� / 5�  )   �� *
GSTRateStr+$
 TwoWay=�$ PropertyChanged=�7 5�  "   �� 5�  &   .R�5�  *   � B � IsSharedSizeScopeB . ��6O   �� $ 
TxtTaxname��$ ActualWidth� 5�  .   �� 5�  2   6F   .+�5�  .   �� $��0��68   $��Right=�6H   �� 5�  2   �66   �� *DataContext.TaxName+ �� " >�6�    �� 5�  2   $�Rate %��67   6G   5   /   5  +   5  '   < 5  "   �� 5  &   " ��6,   .�5  *   ��  � ��$ Right=�6P   5  '   5     5     5     5     �� 5     -   5        $��lblTotalBeforeTax��5  I   $��5��6   $��2��6%   $��2��65   $��Total before Tax��6b   $��	90,10,0,0q�5     $��Center=�6*   6H   �� 5     -   5        $��txtTotalBeforeTax��5  Z   $��5��6   $��3��6#   $��2��63   $��	91,10,0,4q�6G    . $
��Left=�6�   $��Right=�5     
���������5  �   �� $ 	Txtamount��$ ActualWidth���5  I   �� *TotalBeforeTaxStr+$
 TwoWay=�$ PropertyChanged=�6�   �� 5     -   5        $��lblTax��5  I   $��6��6   $��2��6%   $��3��65   $��90,0,0,0q�6p   $��Center=�6�   ��6W   �� *	TaxName+6�   �� 5     -   5        $��txtTax��5  Y   $��6��6   $��3��6#   $��2��63   $��91,2,0,4q�6G    . 
�������$
��Left=�6�   $��Right=�5     ��5  �   �� $ 	Txtamount��$ ActualWidth���5  7   �� *TotalTaxStr+$
 TwoWay=�$ PropertyChanged=�6�   �� 5     -    5        $��lblTotalAfterTax��5  I   $��7��6   $��2��6%   $��2��65   $��90,0,0,0q�6a   $��Center=�6s   �� 5     $�Total after Tax��6    �� 5      �6   �� *CurrencyName+5!     �� 5"     -!   5        $��txtTotalAfterTax��5"  Y   $��7��6   $��3��6#   $��2��63   $��91,2,0,2q�6G    . 
�������$
��Left=�6�   $��Right=�5#     ��5"  �   �� $ 	Txtamount��$ ActualWidth���5#  3   �� *TotalAfterTaxStr+$
 TwoWay=�$ PropertyChanged=�6�   �� 5%     -"   5        $��lblTermsandConditions��5%  ]   $��5��6   $��0,10,0,0q�6&   $��2��68   $��0��6L   $��Terms and Conditions��6z   6�   ]� 5&     $��6��6   $��0��6%   $��4��65   $��2��6F   .+�5'     �� -#   5        $ txtTermsandConditions��5'  '   $��7��6   $	��370��6H   $��0,5,0,0q�6U   C �� TextWrapping$
C Wrap=�5(  m   $
��Left=�6�   $��80��6�   $	��Top=�6�    6   �� *AllFieldsReadonly+$
 TwoWay=�$ PropertyChanged=���5)     �� *TermsAndConditions+$
 TwoWay=�$ PropertyChanged=�6g   5+     �� 5,     $��6��6   $��1��6"   $��2��62   $��2��6G   $	��160��6X   y�5-     �� *VisibilityForImage+$
 TwoWay=�$ PropertyChanged=�.+�5.     ��   
StampStyle#��[ 6   $,��&/SASClient;component/Images/stamp1.png��6>   5/     �� 50       StampTextStyle#��[ 6;   ��6   �� *StatusString+6;   51     �� 54     $��8��6   $��0��6%   $��20��65   �� 55     $��8��6   $��3��6%   $��3��65   $��3��6I   
���  ��$
��Wrap=�6o   ��6�   �� *
PQErrors+$
 TwoWay=�$ PropertyChanged=�6�   ]� 56     $��11��6   $��0��6&   .+�57     �� $��8��6   $
��Left=�6&   $��2��6A   $	��100��6V   #��[ 6b   $��Pay Supplier��6�   ��6�   �� *PaymentToSupplierCommand+6�   58     �� 59     
���  ��$��20��6+   $��1,1,0,34q�67   $	��500��6I   $
��Wrap=�6U   $��3��6�   $��2��6�   $��8��6�   $��2��6�   ��6i   �� $ 
DateErrors�$
 TwoWay=�$ PropertyChanged=�6�   ]� 5;     $��11��6   $��2��6&   $��Right=�66   $��Bottom=�6R   $��3��6m   $��0 0 3 0q�6�   .+�5=     �� -$   5        D ��Name$D btnDuplicate��5=  '   $��10��6   $��	Duplicate��6=   $��	10,10,0,0q�6Q   #���  6d   ��6�   �� *DuplicateCommand+6�   �� 5?     -%   5        $D btnNew��5?  '   $��12��6   $	��New��67   $��	10,10,0,0q�6E   #���  6X   $	��New��6�   ��6~   �� *NewPQCommand+6�   �� 5@     -&   5        $D btnSave��5@  '   $��13��6   $
��Save��68   $��	10,10,0,0q�6G   #���  6Z   ��6�   �� *SaveCommand+6�   �� 5A     -'   5        $D btnClose��5A  '   $��14��6   $��Close��69   $��	10,10,0,0q�6I   #���  6\   ��6�   �� *CloseCommand+6�   5B     5D     5E     5F     
   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SDN.Purchasing.ViewSDN.Purchasing.View  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   -   E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      /    )SDN.Purchasing.View.PurchaseInvoiceBEView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:SDN.Purchasing.View     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   -   Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      $
��1024��5       $
��auto��5	        � 	Resources  5
      ,  &SDN.Common.Converter.DateTimeConverter   DateTimeFormatter.  (SDN.Common.Converter.RowToIndexConverter  RowToIndexConverter9  3SDN.Common.Converter.TextInputToVisibilityConverter " TextInputToVisibilityConverter  BorderStyle �� 
TargetType �� Property �� Value  TextBoxStyle  brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder��%�  &	        &	      &	 &     &	 9     &	 �     &	 �     &	     &	 *      5   
   6@     5   
   6&     5   
   61   �� 5   
   " ��6$   .�5      ��  � ��$ 1q�60   �� 5       � ��
 �   �6,   5      �� 5   
   " ��6%   .�5      ��  � ��$ 0q�60   5      �� 5   
   $ White��6;   �� 5   
   $
 Gray��6;   �� 5   
   $ Black��67   5      .��5      �� $
��Auto=�6   $
��Auto=�66   .��5   
   � $��
10,10,0,10q�6   $
��auto��6#   $
��auto��60     5        
ComboStyle��%#  '��       &	 �     �� 5      " ��6   .�5      ��  � ��$ 25��6/   6<   �� 5        � ��$ 0,0,0,4q�6/   �� 5!       � ��
 �   �64   5"      �� 5#      " ��6+   .�5$      ��  � ��$ 0,0,0,4q�6/   �� 5%       � ��
 �   �64   5&      5'       � RowDefinitions 5(      �� 5)      $��33 �6    6.   �� 5*      $��33 �6    6.   �� 5+      $��33 �6    6.   �� 5,      $��25 �6    6.   �� 5.      $
��Auto �6    60   �� 5/      $��39 �6    6.   �� 50      $��33 �6    6.   �� 51      $��33 �6    6.   �� 52      $��20 �6    6.   �� 53      $��35 �6    6.    � ColumnDefinitions 5:      �� 5;      $	��250 �6#   61   �� 5<      $	��250 �6#   61   �� 5=      $	��160 �6#   61   �� 5>      $	��120 �6#   61   �� 5?      $	��220 �6#   61   .+�5B      ]� $��0��6   $��0��6%   $��2��65   .+�5C      �� -   5        $��lblSupplierName��5C      $��Supplier Name��64   6K   �� 5D      $��*��6   
���  ��$��50,0,0,0q�66   �� 5E      -   5        $��cmbSupplierName��5E       �� 
IsEditable . $��3,2,0,5q�6E   $	��230��5F      $��25��6(   $
��Left=�65   #��[ 5G       �� DisplayMemberPath$ SupplierName��6p   	 �� SelectedValuePath$	 ID��6�   $	��Top=�6�   {�5E   V   �� *AllFieldsEnabled+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���6�   �� *LstSuppliers+ �� SelectedValue 5G   B   �� *SelectedSupplierID+.  (System.Windows.Interactivity.Interaction   Triggers 5H      /  )System.Windows.Interactivity.EventTrigger  5I         	EventName$ SelectionChanged��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5J      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� *!SupplierSelectionChangedCommand+5K      5M      �� 5N      $��10,0,0,0q�6   �� 5O       �� Command 6   �� *%#DataContext.NavigateToClientCommand+ �� RelativeSource ��  �� AncestorType" >� �� CommandParameter 5P      �� *SelectedSupplierID+.�6F   .�5Q      �� $��Supplier Details��6"   $
��Wrap=�6:   5R      5S      5T      ]� 5U      $��0��6   $��0��6%   $��2��65   $��	130,0,0,0q�6I   .+�5V      �� $��17 5 0 0q�6    	 WaterMarkStyle#��[	 62   $
��Left=�5W      $��Search��62   #��[ 6@   y�5X      `� 5Y       `� 	Converter# [ 6'   .1�5Z      ��  �� ElementName$ cmbSupplierName��6&    �� Path$ Text.IsEmpty�6D   �� 5[      $ cmbSupplierName��6&   $ 	IsFocused�6D   5\      5^      5_      �� 5`      -   5        $��lblBlank��5`   5   $��0��6   $��2��6%   $�� ��6G   $��3��6O   6c   �� 5c      -   5        $��lblInvoiceNo��5c   5   $��0��6   $��3��6%   $��Invoice No.��6I   6_   �� 5d      -   5        $��txtInvoiceNo��5d   Z   $
��Left=�6   $	��210��61   $��0��6=   $��4��6J    �� 	MaxLength$ 50��6n   $��9,0,0,5q�5e   n    �� 
IsReadOnly 6   �� *AllFieldsReadonly+$
 TwoWay=�$ PropertyChanged=���6   �� *	InvoiceNo+$
 TwoWay=�$ PropertyChanged=�6�   �� 5g      -   5        $��lblInvoiceDate��5g   5   $��1��6   $��3��6%   $��Invoice Date��6K   6b   ]� 5h      $��1��6   $��4��6&   $
��Left=�67   .+�5i      �� $��*��6   
���  ��$��0,0,2,2q�66   6I   (  "System.Windows.Controls.DatePicker  5j      -   5        $��InvoiceDatepicker��5k      $��4��5j      $	��211��6*   $��1,0,1,4q�67      SelectedDate 5k   .   �� *InvoiceDateCalender+ �� BindingGroupName$ Group1��$ PropertyChanged=�  5l      :	  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name 
 BaseBorderBrush��%�  '	        7   �� 5m      " 	 6    .�5n      ��  � �� 5o   "   �� 5p   &   .R�5q   *   �� $ PART_TextBox��62    . $��0q�6[   $��Stretch=�6o   $��Stretch=�5r   .   $y�Hidden=�6R   #��� 
 6f   .��6�   ��5s   .   `� 5t   2   8   .1�5u   6   �� $ SelectedDate�6>   �� 5v   6   $ 
DateFormat�6>   6R   �� 5w   6   $% DataContext.InvoiceDateCalender�6>    5x   A   �� "  5y   3   .��5z   <   5{   +   5|   '   5~      5      5�      5�      �� 5�      -   5        $ PART_TextBox1��5�   o   $��-262 -5 0 0q�6   $��21��6/   #��[ 6;    .  $��0q�6�   $��Stretch=�6�   $��Stretch=�5�      $	��160��6�   ��65   �� $ InvoiceDateStr�$
 TwoWay=�$ PropertyChanged=�.��6�   5�      5�      ]� 5�      $��1��6   $��0��6%   $��2��65   .+�5�      �� -	   5        $��
lblOurPONo��5�      $��
Our PO No.��6/   6D   �� 5�      -
   5        $��
txtOurPONo��5�   C   $	��230��6   $
��Left=�6&   $��76,0,0,5q�6U    . ��5�      �� *	OurPONo+$
 TwoWay=�$ PropertyChanged=�6`   �� 5�      $��Balance��6   $
��Left=�6,   $��11,0,0,0q�6G   6[   5�      ]� 5�      $��2��6   $��0��6%   $��2��65   .+�5�      �� $��Credit Limit Amount��6   $��Right=�68   $��0,0,1,0q�6T   6g   5�      �� 5�      $��1��6   $��2��6%   $��10,0,0,0q�65   $
��Left=�6d   ��6G   �� *Sup_Balance+6�   �� 5�      $��2��6   $��2��6%   $��10,0,0,0q�65   $
��Left=�6n   ��6G   �� *Sup_CreditLimitAmount+6�   �� 5�      -   5        $��lblPaymentDueDate��5�   5   $��2��6   $��3��6%   $��Payment Due Date��6N   6i   ]� 5�      $��2��6   $��4��6&   $
��Left=�67   .+�5�      �� $��*��6   
���  ��$��0,0,2,2q�66   6I     5�      -   5        $��PayDueDatepicker��5�      $��6��5�      $	��211��6*   $��1,0,1,4q�67    5�   ,   �� *PayDueDateCalender+$ Group1��$ PropertyChanged=�  5�      ��%�  '	        7   �� 5�      " 	 6    .�5�      ��  � �� 5�   "   �� 5�   &   .R�5�   *   �� $ PART_TextBox��62    . $��0q�6[   $��Stretch=�6o   $��Stretch=�5�   .   $y�Hidden=�6Q   #��� 
 6e   .��6�   ��5�   .   `� 5�   2   8   .1�5�   6   �� $ SelectedDate�6>   �� 5�   6   $ 
DateFormat�6>   6R   �� 5�   6   $$ DataContext.PayDueDateCalender�6>    5�   A   �� "  5�   3   .��5�   <   5�   +   5�   '   5�      5�      5�      5�      �� 5�      -   5        $ PART_TextBox��5�   o   $��-262 -5 0 0q�6   $��21��6/   #��[ 6;    .  $��0q�6�   $��Stretch=�6�   $��Stretch=�5�      $	��160��6�   ��65   �� $ PaymentDueDateStr�$
 TwoWay=�$ PropertyChanged=�.��6�   5�      5�      �� 5�      $��2��6   $
��Left=�6"   $��0��6=   $	��150��6M   $��Enter Purchases of P&S��6Y     ButtonStyle#��[ 5�   <   ��6   �� *NavigateToPICommand+6c   �� 5�      $��3��6   $��0��6%   $��6��65   
�������$��Italic$�6[   ��If you returned a Business Cost or Expense to Supplier, enter minus amount. If Total has minus value, Simple will automatically create a Debit Note.5�      ]� 5�      $��3��6   $��4��6%   $��8,3,5,5q�65   $��Right=�6F   .+�5�      	� -   5        $��rdnExcludeGST��5�       	� 	GroupName$ grpTax��6�   {�63   �� *AllFieldsEnabled+$
 TwoWay=�$ PropertyChanged=� d� 	IsChecked 6�   �� *ExcludingTax+$
 TwoWay=�$ PropertyChanged=� 5�        5�      $ Checked��6)   . 5�           CommandParameter$
 SSRT��6a    64   �� *ExcludeTaxCheckedCommand+6a   5�      5�      �� 5�      -   5        $��lblExcludeGST��5�      $��8,0,10,0q�62   �� 5�      $
�exc.��6    �� 5�      �6   �� *	TaxName+5�      	� 5�      -   5        $��rdnIncludeGST��5�      $ grpTax��6�   {�64   �� *AllFieldsEnabled+$
 TwoWay=�$ PropertyChanged=� 6�   �� *IncludingTax+$
 TwoWay=�$ PropertyChanged=� 5�        5�      $ Checked��6)   . 5�        $
 SSRT��6a    64   �� *IncludeTaxCheckedCommand+6a   5�      5�      �� 5�      -   5        $��lblIncludeGST��5�      $��10,0,0,0q�62   �� 5�      $
�inc.��6    �� 5�      �6   �� *	TaxName+5�      5�      � 5�      $	��995��6   $
��Left=�6   $��0,0,0,0q�6_   $��4��6p   $��0��6}   $��6��6�   ��6;   �� *PIFormGridHeight+.+�5�      � .+�5�      &
   System.Windows.Controls.DataGrid
  -   5          
 Name$  CustomGridLines��5�      $��0��6`   ! 
  GridLinesVisibility$	! All=�5�   U   " 
  HorizontalGridLinesBrush
" �����# 
  VerticalGridLinesBrush
# �����$ 
  AutoGenerateColumns$ .  % 
  CanUserSortColumns% .  $& 
  HorizontalScrollBarVisibility$& Hidden=�5�      "' 
  VerticalScrollBarVisibility$' Disabled=�6C     BackHeaderStyle20( 
  ColumnHeaderStyle#( [ 5�      ) 
  HeadersVisibility$	) All=�6R   ��5�   8   �� *BackGroundLines+��5�      �� $ grdPandS��$ ActualHeight���6q   �� $ grdPandS��$ ActualWidth�* 
  Columns* 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn+   Header$+  ��61   ,   Width5  /System.Windows.Controls.DataGridLengthConverter$	, 400 6U   1  +System.Windows.Controls.DataGridBoundColumn-   Binding- 6;   �� *Col0+6c     5�      $+  ��61   $	, 340 6U   - 6;   �� *Col1+6c     5�      $+  ��61   $	, 145 6U   - 6;   �� *Col2+6c     5�      $+  ��61   $, 90 6U   - 6;   �� *Col3+6b   5�      
  5�      -   5        $��grdPandS��5�   Z   $
��Left=�6   $��8��6:   $	��995��6N   $	! All=�6j   $��1q�5�      
���   �$ .  . 
  CanUserAddRows. . $��Disabled=�5�   O   / 
  CanUserReorderColumns/ .  % . 0 
  CanUserDeleteRows0 . 
������ $
��Auto=�5     ��.    HeaderStyle20#( [ 5  H   1 
  
IsReadOnly1 5�   �   �� *AllFieldsReadonly+$
 TwoWay=�$ PropertyChanged=���5�   @   �� *PIFormGridHeight+* 5       5     -   5        description��$	, 400 5  �   - 6G   �� *Description+$
 TwoWay=�$ PropertyChanged=�2   HeaderTemplate2 5  "   �� 5	  &   .R�5
  *   �  5  .   �� 5  2   6B    5  .   �� 5  2   ��6C   �� $ description��$ ActualWidth�.+�5  .   ]� $��0��68   $��0��6E   $
��Left=�6U   .+�5  2   �� �� 5  #   $�Description��6'   5  3   5  /   5  +   5  '   3   EditingElementStyle3 5  "   �� 5  &   " ��6,   .�5  *   ��  �@��	MaxLength$ 50��6F   5  '   5     4  .System.Windows.Controls.DataGridComboBoxColumn  5      $	, 340 66   4   DisplayMemberPath$4 AccountName��5!     -   5        actName��5   SelectedValuePath$5 	AccountID��5"     6   SelectedValueBinding6 5#     �� *SelectedAccountId+$
 TwoWay=�$ PropertyChanged=�2 5$  "   �� 5%  &   .R�5&  *   �  5'  .   �� 5(  2   6B    5*  .   �� 5+  2   ��6C   �� $ actName��$ ActualWidth�.+�5-  .   ]� $��0��68   $��0��6E   $
��Left=�6U   .+�5.  2   �� �� 5/  #   $�Account Name��6'   51  3   52  /   53  +   54  '   7   ElementStyle7 5I  "   �� 5J  &   " ��6,   .�5K  *   ��  � �� 6I   �� $ DataContext.Accounts� �� " 
 �� 5L  *    � �� 5M  .   �� 5N  2   .R�5P  6   � 8 �Name$8 gd��6;   
���   �$	��350��6f    5Q  :   �� 5R  >   $	��200 �6O   �� 5S  >   $	��150 �6O   .+�5U  :   �� $��0��6D   ��6T   �� *AccountName+5W  7   9 �� Triggers9 5X  6   P� 5Y  :   : P� Property: �@��
IsSelected; P� Value; . . �5Z  >   �� < �� 
TargetName$< gd��6E    � ��
 �����6{   �� 5[  >   $< gd��6E    � ��
 �   �6�   5\  ;   P� 5]  :   : �@J�IsMouseOver; . . �5^  >   �� $< gd��6E    � ��
 �����6{   �� 5_  >   $< gd��6E    � ��
 �   �6�   5`  ;   5b  3   5e  +   5f  '   =   EditingElementStyle= 5h  "   �� 5i  &   " ��6,   .�5j  *   ��  �@��
IsEditable . 6V   �� 5k  *    � y�$ Visible=�6G   6Y   �� 5l  *    � �� 6I   �� $ DataContext.Accounts� �� " 
 �� 5m  *    � �� 5n  .   �� 5o  2   .R�5q  6   � $8 gd��6;   
���   �$	��350��6f    5r  :   �� 5s  >   $	��200 �6O   �� 5t  >   $	��150 �6O   .+�5v  :   �� $��0��6D   ��6T   �� *AccountName+�� 5w  :   $��1��6D   ��6T   �� *AccountTypeName+5x  7   9 5y  6   P� 5z  :   : �@��
IsSelected; . . �5{  >   �� $< gd��6E    � ��
 �����6{   �� 5|  >   $< gd��6E    � ��
 �   �6�   5}  ;   P� 5~  :   : �@J�IsMouseOver; . . �5  >   �� $< gd��6E    � ��
 �����6{   �� 5�  >   $< gd��6E    � ��
 �   �6�   5�  ;   5�  3   5�  +   5�  '   5�       5�     -   5        	Txtamount��$+ Amount��5�  D   $	, 145 6�   - 6V   �� *PQAmountStr+$
 TwoWay=�$ PropertyChanged=�2 5�  "   �� 5�  &   .R�5�  *   �  5�  .   �� 5�  2   6B    5�  .   �� 5�  2   ��6C   �� $ 	Txtamount��$ ActualWidth�.+�5�  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5�  2   �� �� 5�  #   $�Amount��6'   5�  3   5�  /   5�  +   5�  '   >   ElementStyle> 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   6`   5�  '   3 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  �@��	MaxLength$ 18��6F   �� 5�  *    � ��$ Right=�6P   5�  '   5�       5�     -   5        
TxtTaxname��$, 90 5�  I   $4 TaxRate��6U   $5 TaxID��5�     6 61   �� *SelectedTaxID+$
 TwoWay=�$ PropertyChanged=�2 5�  "   �� 5�  &   .R�5�  *   � ? � IsSharedSizeScope? . ��6O   �� $ 
TxtTaxname��$ ActualWidth� 5�  .   �� 5�  2   6F   .+�5�  .   �� $��0��68   $��Right=�6H   �� 5�  2   �66   �� *DataContext.TaxName+ �� " >�6�    �� 5�  2   $�Rate %��67   6G   5�  /   5�  +   5�  '   7 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � �� 6H   �� $ DataContext.Taxes� �� " 
 �� 5�  *    � ��$ Right=�6W   6g   5�  '   = 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � �� 6H   �� $ DataContext.Taxes� �� " 
 �� 5�  *    �@��
IsEditable . 6G   �� 5�  *    � ��$ Right=�6W   6g   -   5        5�  '   5�     5�     5�     5�     �� 5�     -   5        $��lblTotalBeforeTax��5�  I   $��5��6   $��2��6%   $��2��65   $��Total before Tax��6b   $��	80,10,0,0q�5�     $��Center=�6*   6H   �� 5�     -   5        $��txtTotalBeforeTax��5�  h   $��11��6   $��5��6$   $��3��61   $��2��6A   $��	79,10,0,4q�6U    . $
��Left=�6�   $��Right=�5�     
���������5�  �   �� $ 	Txtamount��$ ActualWidth���5�  I   �� *TotalBeforeTaxStr+$
 TwoWay=�$ PropertyChanged=�6�   �� 5�     -   5        $��lblTax��5�  I   $��6��6   $��2��6%   $��3��65   $��80,0,0,0q�6p   $��Center=�6�   ��6W   �� *	TaxName+6�   �� 5�     -   5        $��txtTax��5�  g   $��12��6   $��6��6$   $��3��61   $��2��6A   $��79,2,0,4q�6U    . 
�������$
��Left=�6�   $��Right=�5�     ��5�  �   �� $ 	Txtamount��$ ActualWidth���5�  7   �� *TotalTaxStr+$
 TwoWay=�$ PropertyChanged=�6�   �� 5�     -   5        $��lblTotalAfterTax��5�  I   $��7��6   $��2��6%   $��2��65   $��80,0,0,0q�6a   $��Center=�6s   �� 5�     $�Total after Tax��6    �� 5�     �6   �� *CurrencyName+5�     �� 5�     -   5        $��txtTotalAfterTax��5�  g   $��13��6   $��7��6$   $��3��61   $��2��6A   $��79,2,0,2q�6U    . 
�������$
��Left=�6�   $��Right=�5�     ��5�  �   �� $ 	Txtamount��$ ActualWidth���5�  3   �� *TotalAfterTaxStr+$
 TwoWay=�$ PropertyChanged=�6�   �� 5�     -   5        $��lblTermsandConditions��5�  \   $��5��6   $��0,5,0,0q�6&   $��2��67   $��0��6K   $��Terms and Conditions��6y   6�   ]� 5�     $��6��6   $��0��6%   $��4��65   $��2��6F   .+�5�     �� -    5        $ txtTermsandConditions��5�     $	��370��6;   $��0,5,0,0q�6H   @ �� TextWrapping$
@ Wrap=�5�  m   $
��Left=�6�   $��80��6�   $	��Top=�6�    6   �� *AllFieldsReadonly+$
 TwoWay=�$ PropertyChanged=���5�     �� *TermsAndConditions+$
 TwoWay=�$ PropertyChanged=�6f   5�     �� 5�     $��7��6   $��1��6>   $��Right=�6N   $	��100��6j   ��6!   �� *	ImgSource+6x   �� 5�     $��8��6   $��2��6%   $��3��65   $��3��6I   
���  ��$
��Wrap=�5�     ��6,   �� *
PQErrors+$
 TwoWay=�$ PropertyChanged=�6x   ]� 5�     $��11��6   $��0��6&   .+�5�     �� $��14��6   $
��Left=�6'   $��2��6B   $	��100��6W   #��[ 6c   $��Pay Supplier��6�   ��6�   �� *PaymentToSupplierCommand+6�   5�     ]� 5�     $��11��6   $��4��6&   $��	120 2 0 0q�6:   .+�5�     �� 
�������$��Italic$�6.   $����In Account Name drop-down list You can select user created Cost, user created Expenses, and user 
created Asset accounts only. Expense to a Supplier.��6A   6�   5�     �� 5�     
���  ��$��20��6+   $��	133,0,0,0q�67   $	��365��6J   $
��Wrap=�6V   $��3��6�   $��2��6�   $��8��6�   ��6j   �� $ 
DateErrors�$
 TwoWay=�$ PropertyChanged=�6�   ]� 5�     $��11��6   $��2��6&   $��Right=�66   $	��top=�6R   $��3��6j   $��0 0 10 0q�6~   .+�5     �� -!   5        A ��Name$A btnNew��5     $	��New��6)   $��	10,10,0,0q�67   #���  6J   $	��New��6�   ��6p   �� *NewPQCommand+6�   �� 5     -"   5        $A btnSave��5     $
��Save��6*   $��	10,10,0,0q�69   #���  6L   ��6r   �� *SaveCommand+6�   �� 5     -#   5        $A 	btnCancel��5     $��Close��6,   $��	10,10,0,0q�6c   #���  6v   ��6<   �� $ CloseCommand�6�   5     5     5     5     
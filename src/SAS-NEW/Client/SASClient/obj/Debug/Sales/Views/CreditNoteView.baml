   M S B A M L   `   `   `  ����E  ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common  5      D @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SDN.Sales.ViewsSDN.Sales.Views 5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5
      O6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter  5      $   SDN.Sales.Views.CreditNoteView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;my,clr-namespace:SDN.Common;assembly=SDN.Common     5      /localclr-namespace:SDN.Sales.Views     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5
      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      $
��1024��5	        � 	Resources  5      ,   &SDN.Common.Converter.DateTimeConverter   DateTimeFormatter.   (SDN.Common.Converter.RowToIndexConverter  RowToIndexConverter4   .SDN.Common.Converter.BoolToVisibilityConverter  	BoolToVis  BorderStyle �� 
TargetType �� Property �� Value  TextBoxStyle��%  &	        &	      &	 &     &	 9     &	 �       5   
   6@     5   
   6&     5   
   6,   �� 5   
   " ��6$   .�5      ��  � ��$ 1q�60   �� 5       � ��
 �   �6,   5      �� 5   
   " ��6%   .�5      ��  � ��$ 0q�60   5      5      .��5      �� $
��Auto=�6   $
��Auto=�66   .��5   
   � $��
10,10,0,10q�6   $
��auto��6#   $
��auto��60     5        
ComboStyle��%#  '��       &	 �     �� 5      " ��6   .�5      ��  � ��$ 24��6/   6<   �� 5       � ��$ 0,0,0,2q�6/   �� 5        � ��
 �   �64   5!      �� 5"      " ��6+   .�5#      ��  � ��$ 0,0,0,2q�6/   �� 5$       � ��
 �   �64   5%      5&       � RowDefinitions 5'      �� 5(      $��30 �6    6.   �� 5)      $��30 �6    6.   �� 5*      $��30 �6    6.   �� 5+      $��17 �6    6.   �� 5,      $��17 �6    6.   �� 5-      $��27 �6    6.   �� 5.      $
��Auto �6    60   �� 5/      $��33 �6    6.   �� 50      $��33 �6    6.   �� 51      $��33 �6    6.   �� 52      $
��Auto �6    60    � ColumnDefinitions 5:      �� 5;      $	��250 �6#   61   �� 5<      $	��250 �6#   61   �� 5=      $��90 �6#   60   �� 5>      $	��180 �6#   61   �� 5?      $	��220 �6#   61   .+�5B      ]� $��0��6   $��0��6%   $��2��65   .+�5C      �� -   5        $��lblCustomerName��5C      $��Customer Name��64   6L   �� 5E      -   5        $��cmbCustomerName��5E      $��37,2,0,0q�63   {�.  $	��212��5F      $��20��6)   $
��Left=�66   
���   � �� DisplayMemberPath$ 	FirstName��5G   Q    �� SelectedValuePath$ 
CustomerID��6o   $	��Top=�6�   ��5E   X   �� *LstCustomers+ �� SelectedValue 5G   #   �� *SelectedCustomerID+.  (System.Windows.Interactivity.Interaction	   Triggers	 5H      /  )System.Windows.Interactivity.EventTrigger  5I      
   	EventName$
 SelectionChanged��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5J      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� *!CustomerSelectionChangedCommand+5K      5M      �� 5N      $��10,0,0,0q�6   �� 5O       �� Command 6   �� *%#DataContext.NavigateToClientCommand+ �� RelativeSource ��  �� AncestorType" >� �� CommandParameter 5P      �� *SelectedCustomerID+.�6F   .�5Q      �� $��Customer Details��6"   $
��Wrap=�6:   5R      5S      5T      �� 5U      -   5        $��lblBlank��5U   5   $��0��6   $��2��6%   $�� ��6G   $��3��6O   6c   �� 5W      -   5        $��lblCustomerDebitNoteNo��5W   5   $��0��6   $��3��6%   $��Customer Debit Note No.��6S   6u   �� 5X      -   5        $��txtCustomerDebitNoteNo��5X   \   $��0��6   $��4��6#   $	��212��63   $
��Left=�6?   $��5,0,0,0q�6z   ��5Y      �� *CustomerDebitNoteNo+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6j   ]� 5[      $��2��6   $��0��6&   $��2��66   $
��Left=�6J   .+�5\      �� -   5        $��lblCreditNoteDate��5\   9   $��1��6   $��3��6)   $��Credit Note Date��6R   6m   (  "System.Windows.Controls.DatePicker  5]      -   5        $	��212��5]      $��25��6)   $��33,0,2,0q�65   {�.     SelectedDate 5^      �� *
CreditDate+ �� BindingGroupName$ Group1��$ PropertyChanged=�  5_      :	  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name �� 
IsReadOnly  BaseBorderBrush `� 	Converter �� Path��%�  '	        7   �� 5`      " 	 6    .�5a      ��  � �� 5b   "   �� 5c   &   .R�5d   *   �� $ PART_TextBox��62    . $��0q�6[   $��Stretch=�6o   $��Stretch=�5e   .   #���  6R   .��6�   ��5f   .   `� 5g   2   8   .1�5h   6   �� $ SelectedDate�6>   �� 5i   6   $ 
DateFormat�6>   6R   �� 5j   6   $ DataContext.CreditDate�6>    5k   A   �� "  5l   3   .��5m   <   5n   +   5o   '   5q      5r      5s      5t      5u      ]� 5w      $��1��6   $��0��6%   $��2��65   .+�5x      �� -   5        $��lblCreditNoteNo��5x      $��Credit Note No.��64   6N   �� 5y      $��40,2,0,0q�6   $��24��6-   $��1q�69   
���   �$	��212��6a   $
��Left=�5z      ._�5{      �� �� 5|      {�.  $
��Wrap=�6Q   ��6%   �� *
CreditNo+6Q   5�      5�      5�      �� 5�      -	   5        $ ��lblCustomerDebitNoteAmount��5�   7   $��2��6   $��3��6'   $ ��Customer Debit Note Amount��6Y   6~   �� 5�      -
   5        $!��txtCustomerCreditNoteAmount��5�   ]   $	��212��6   $��2��6"   $��4��60   $
��Left=�6@   $��5,0,0,0q�6�   ��5�      �� *CustomerDebitNoteAmount+$ TwoWay=�$ PropertyChanged=�6p   �� 5�      -   5        $��lblCustomerDebitNoteDate��5�   8   $��1��6   $��3��6'   $��Customer Debit Note Date��6X   6z     5�      -   5        $!��CustomerDebitNoteDatepicker��5�      $��1��6<   $��4��6J   $	��212��6[   $��5,0,0,0q�6g   $
��Left=�6x    5�      �� *CustomerDebitNoteDateCalender+$ Group1��$ PropertyChanged=�  5�      ��%�  '	        7   �� 5�      " 	 6   .�5�      ��  � �� 5�      �� 5�   "   .R�5�   &   �� $ PART_TextBox��6.    . $��0q�6W   $��Stretch=�6k   $��Stretch=�5�   .   $y�Hidden=�6Q   #���  6e   .��6�   ��5�   *   `� 5�   .   8   .1�5�   2   �� $ SelectedDate�6:   �� 5�   2   $ 
DateFormat�6:   6N   �� 5�   2   $/ )DataContext.CustomerDebitNoteDateCalender�6:    5�   A   �� "  5�   /   .��5�   8   5�   '   5�   #   5�      5�      5�      5�      �� 5�      -   5        $ PART_TextBox��5�   T   $��
-29 -1 0 0q�6   $��21��6+   $��4��67   $��1��6G    .  $��0 0 0 0q�6~   $��Stretch=�6�   $��Stretch=�5�      $	��180��6�   ��65   �� $ CustomerDebitNoteDateStr�$ TwoWay=�$ PropertyChanged=�.��6�   5�      �� 5�      $��3��6   $��0��6%   $��6��65   
�������$��Italic$�6[   ��To create a Credit Note, create a Sales Invoice Total with minus value (Sales Return), and Simple will automatically create a Credit Note.5�      ]� 5�      $��5��6   $��0��6%   $��2��65   $��0,0,0,2q�6I   .+�5�      �� -   5         ��Name$ btnAdjustCreditNote��5�      $��23��66   $	��Top=�6B   $
��auto��6a   $/��)Adjust Credit Note against Sales Invoices��6n     ButtonStyle#���  6�   ��5�      �� *AdjustCreditNoteCommand+��6E   �� *
CreditNo+6m   �� 5�      $��OR��6   $��15,0,0,5q�6&   6:   �� 5�      -   5        $ btnRefundMoney��5�   %   $��23��6   $	��Top=�6=   $	��180��6]   $��Refund money to Customer��6i   #���  5�      $	��New��6p   ��6?   �� *RefundMoneyToCustomerCommand+6�   5�      � 5�      $	��988��6   $��6��6E   $��0��6R   $��5��6b   $��0,0,0,0q�6v   ��6    �� *PIFormGridHeight+.+�5�      � .+�5�      &
   System.Windows.Controls.DataGrid
  -   5         
 Name$ CustomGridLines��5�      $��0��6`    
  CanUserSortColumns .   
  GridLinesVisibility$	 All=�5�   U    
  HorizontalGridLinesBrush
 ����� 
  VerticalGridLinesBrush
 ����� 
  AutoGenerateColumns .  $  
  HorizontalScrollBarVisibility$  Hidden=�5�      "! 
  VerticalScrollBarVisibility$! Disabled=�6C     BackHeaderStyle20" 
  ColumnHeaderStyle#" [ 5�      # 
  HeadersVisibility$	# All=�6R   $��0,0,0,0q�6j   ��5�   8   �� *BackGroundLines+��5�      �� $ �� ElementName$$ grdPandS��$ ActualHeight���6q   �� $$ grdPandS��$ ActualWidth�% 
  Columns% 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn&   Header$&  ��61   '   Width5  /System.Windows.Controls.DataGridLengthConverter$	' 230 6U   1  +System.Windows.Controls.DataGridBoundColumn(   Binding( 6;   �� *Col0+6c     5�      $&  ��61   $	' 230 6U   ( 6;   �� *Col1+6c     5�      $&  ��61   $	' 110 6U   ( 6;   �� *Col2+6c     5�      $&  ��61   $	' 120 6U   ( 6;   �� *Col3+6c     5�      $&  ��61   $' 60 6U   ( 6;   �� *Col4+6b     5�      $&  ��61   $	' 145 6U   ( 6;   �� *Col5+6c     5�      $&  ��61   $' 75 6U   ( 6;   �� *Col6+6b   5�      
  5�      -   5        $��grdPandS��5�   J   $��0��6   $
��Left=�6/   $	 All=�6Z   ) 
  
IsReadOnly) . $	��988��6�   $��1q�5�      
���   � .  * 
  CanUserAddRows* . $��Disabled=�5�   O   + 
  CanUserReorderColumns+ .   . , 
  CanUserDeleteRows, . 
������ $
��Auto=�5�      ��.   	 HeaderStyle20#" [	 6[   ��5�   ?   �� *PIFormGridHeight+% 5�      4  .System.Windows.Controls.DataGridComboBoxColumn  5�      $	' 230 66   -   5        	chkPSCode��-   DisplayMemberPath$- PSCode��5�      .   SortMemberPath$. PSCode��61   /   SelectedValuePath$/ ID��5�      0   SelectedValueBinding0 5�      �� *SelectedPSID+$ TwoWay=�$ PropertyChanged=�1   HeaderTemplate1 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   6B    5�   .   �� 5�   2   ��6C   �� $$ 	chkPSCode��$ ActualWidth�.+�5�   .   ]� $��0��68   $��0��6E   .+�5�   2   �� $��txtHeaderPandScode��6<   �� 5�   "   $�Product & Service Code��6&   6J   5�   3   �� 5�   2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�   1   $��20��6<   $
��Left=�5�   ,   5�   /   5�   +   5�   '   2   ElementStyle2 5�   "   �� 5�   &   " ��6,   .�5�   *   ��  � �� 6H   �� $$ DataContext.ProductAndServices� �� " 
 5�   '   3   EditingElementStyle3 5�   "   �� 5�   &   " ��6,   .�5�   *   ��  � �� 6H   �� $$ DataContext.ProductAndServices� �� " 
 �� 5�   *    �@��
IsEditable . 6G   5�   '   5�        5�      $	' 230 65   -   5        	chkPSName��$- PSName��5�      $. PSName��61   $/ ID��5�      0 5�      �� *SelectedPSID+$ TwoWay=�$ PropertyChanged=�1 5�   "   �� 5�   &   .R�5   *   �  5  .   �� 5  2   6B    5  .   �� 5  2   ��6C   �� $$ 	chkPSName��$ ActualWidth�.+�5  .   ]� $��0��68   $��0��6E   .+�5  2   �� $��txtHeaderPandSname��6<   �� 5	  "   $�Product & Service Name��6&   6J   5
  3   �� 5  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5  1   $��20��6<   $
��Left=�5  ,   5  /   5  +   5  '   2 5  "   �� 5  &   " ��6,   .�5  *   ��  � �� 6H   �� $$ DataContext.ProductAndServices� �� " 
 5  '   3 5  "   �� 5  &   " ��6,   .�5  *   ��  � �� 6H   �� $$ DataContext.ProductAndServices� �� " 
 �� 5  *    �@��
IsEditable . 6G   5  '   5$       5%     -   5        
txtQty��$. SQQty��5%  A   $	' 110 6�   ( 6Z   �� *SQQty+$ TwoWay=�$ 	LostFocus=�1 5&  "   �� 5'  &   .R�5(  *   �  5)  .   �� 5*  2   6B    5,  .   �� 5-  2   ��6C   �� $$ txtQty��$ ActualWidth�.+�5/  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�50  2   �� �� 51  #   $�Quantity��6'   6:   �� 52  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��53  1   $��20��6<   $
��Left=�54  ,   56  /   57  +   58  '   4   ElementStyle4 5?  "   �� 5@  &   " ��6,   .�5A  *   ��  � ��$ Right=�6P   5B  '   5   EditingElementStyle5 5D  "   �� 5E  &   " ��6,   .�5F  *   ��  �@��	MaxLength$ 5��6F   �� 5G  *    � ��$ Right=�6W   5H  '   5J       5K     -   5        Txtprice��$. SQPrice��5K  D   $& Price��6`   $	' 120 6�   ( 6q   �� *	SQPrice+6 �� StringFormat$6 
{0:0.####}��$ TwoWay=�$ 	LostFocus=�1 5Q  "   �� 5R  &   .R�5S  *   �  5T  .   �� 5U  2   6B    5W  .   �� 5X  2   ��6C   �� $$ Txtprice��$ ActualWidth�.+�5Z  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5[  2   �� �� 5\  #   $�Price��6'   67   �� 5]  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5^  1   $��20��6<   $
��Left=�5_  ,   5`  /   5a  +   5b  '   4 5d  "   �� 5e  &   " ��6,   .�5f  *   ��  � ��$ Right=�6P   5g  '   5 5i  "   �� 5j  &   " ��6,   .�5k  *   ��  �@��	MaxLength$ 10��6F   �� 5l  *    � ��$ Right=�6W   5n  '   5q       5r     -   5        Txtdiscount��7   CanUserSort7 .  $& Disc %��5s     $' 60 6�    
 HeaderStyle20Right8   HeaderStyle#8 [
 6�   ( 6+   �� *
SQDiscount+$ TwoWay=�$ 	LostFocus=�$
6 {0}%��4 5z  "   �� 5{  &   " ��6,   .�5|  *   ��  � ��$ Right=�6P   5}  '   5 5  "   �� 5�  &   " ��6,   .�5�  *   ��  �@��	MaxLength$ 10��6F   �� 5�  *    � ��$ Right=�6W   5�  '   5�       5�     -   5        	Txtamount��$. SQAmountStr��5�  D   $& Amount��6a   $	' 145 6�   9   
IsReadOnly9 . ( 6s   �� *SQAmountStr+1 5�  "   �� 5�  &   .R�5�  *   �  5�  .   �� 5�  2   6B    5�  .   �� 5�  2   ��6C   �� $$ 	Txtamount��$ ActualWidth�.+�5�  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5�  2   �� �� 5�  #   $�Amount��6'   68   �� 5�  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�  1   $��20��6<   $
��Left=�5�  ,   5�  /   5�  +   5�  '   4 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   5�  '   5�       5�     -   5        
TxtTaxname��$& Tax Rate��5�  *   $' 75 5�  )   9 . ( 5�  )   �� *	GSTRate+$ TwoWay=�$ PropertyChanged=�$
6 {0}%��1 5�  "   �� 5�  &   .R�5�  *   � : � IsSharedSizeScope: . ��6O   �� $$ 
TxtTaxname��$ ActualWidth� 5�  .   �� 5�  2   6F   .+�5�  .   �� $��0��68   $��Right=�6I   �� 5�  2   �66   �� *DataContext.TaxName+ �� " >�6�    �� 5�  2   $�Rate %��67   6G   5�  /   5�  +   5�  '   4 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   5�  '   5�     5�     5�     5�     �� 5�     -   5        $��lblTotalBeforeTax��5�  I   $��7��6   $��2��6%   $��2��65   $��Total before Tax��6b   $��Center=�5�     $��90,0,0,0q�61   6H   �� 5�     -   5        $��txtTotalBeforeTax��5�  Z   $��7��6   $��3��6#   $��2��63   $��	160,5,0,0q�6G    . $
��Left=�6�   $��Right=�5�     
���������5�  �   �� $$ 	Txtamount��$ ActualWidth���5�  I   �� *TotalBeforeTaxStr+$ TwoWay=�$ PropertyChanged=�6�   �� 5�     -   5        $��lblTax��5�  d   $��8��6   $��2��6%   $��Center=�65   $��2��6P   $��90,0,0,0q�6�   ��6r   �� *	TaxName+6�   �� 5�     -   5        $��txtTax��5�  Z   $��8��6   $��3��6#   $��2��63   $��	160,0,0,0q�6G    . 
�������$
��Left=�6�   $��Right=�5�     ��5�  �   �� $$ 	Txtamount��$ ActualWidth���5�  7   �� *TotalTaxStr+$ TwoWay=�$ PropertyChanged=�6�   �� 5�     -   5        $��lblTotalAfterTax��5�  J   $��9��6   $��2��6%   $��2��65   $��Center=�6b   $��90,0,0,0q�6}   �� 5�     $�Total after Tax��6    �� 5�     �6   �� *CurrencyName+5�     �� 5�     -   5        $��txtTotalAfterTax��5�  Z   $��9��6   $��3��6#   $��2��63   $��	160,0,0,0q�6G    . 
�������$
��Left=�6�   $��Right=�5�     ��5�  �   �� $$ 	Txtamount��$ ActualWidth���5�  3   �� *TotalAfterTaxStr+$ TwoWay=�$ PropertyChanged=�6�   �� 5�     -   5        $��lblTermsandConditions��5�  ]   $��7��6   $��0,10,0,0q�6&   $��2��68   $��0��6L   $��Terms and Conditions��6z   6�   ]� 5�     $��8��6   $��0��6%   $��2��65   $��2��6F   .+�5�     �� -    5        $ txtTermsandConditions��5�     $��65��69   $	��370��6G   $��0,0,0,0q�6T   ; �� TextWrapping$
; Wrap=�5�  m   $
��Left=�6�   $	��Top=�6�    6   �� *AllFieldsReadonly+$ TwoWay=�$ PropertyChanged=���5�     �� *TermsAndConditions+$ TwoWay=�$ PropertyChanged=�6g   5�     �� 5�     $��117,14,0,22q�6   $	��250��6.   $��Center=�5�     $��8��6;   $��1��6H   $��2��6X   
���  ��< J� RenderTransformOrigin$< 0.668,0.529&�6�   $��3��6�   $��30��6  $
��Bold"�6  = �� TextAlignment$= Center=�6"  y�6i   �� $ RubberAdjusted�> �� 	Converter#> [ 
ADJUSTED6D  �� 5�     $��10��6   $��1��6(   $	��500��68   $��4��6D   $��	0 -10 0 0q�6X   $��Right=�6k   .+�5�     �� 
���  ��$��20��6/   $��90 -30 0 -60q�6;   $	��400��6Q   $
��Wrap=�6]   ��6q   �� $ 
DateErrors�$ TwoWay=�$ PropertyChanged=�6�   ]� 5�     $��10��6   $��1��6*   $	��200��6:   $��Right=�6F   $	��Top=�6b   $��4��6z   $��0,0,3,0q�6�   $��55��6�   .+�5�     �� -!   5        $ btnPrint��5�  +   $��10��6   $��0,25,0,0q�6=   $��Print��6O   #���  6�   ��6_   �� *clickCommand+$ TwoWay=���6�   �� $ CreditNo�6�   �� 5�     -"   5        $ btnSave��5�     $
��Save��6.   $��	10,25,0,0q�6=   #���  6P   ��6v   �� *SaveCommand+6�   �� 5�     -#   5        $ btnClose��5�     $��Close��6/   $��	10,25,0,0q�6?   #���  6R   ��6x   �� *CloseCommand+6�   5�     5�     5�     5�     5�     
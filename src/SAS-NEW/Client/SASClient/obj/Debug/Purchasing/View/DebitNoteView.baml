   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SDN.Purchasing.ViewSDN.Purchasing.View  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5
      O6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      '    !SDN.Purchasing.View.DebitNoteView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:SDN.Purchasing.View     5      ;my,clr-namespace:SDN.Common;assembly=SDN.Common     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5
      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      $
��1024��5	        � 	Resources  5      ,  &SDN.Common.Converter.DateTimeConverter   DateTimeFormatter.  (SDN.Common.Converter.RowToIndexConverter  RowToIndexConverter4  .SDN.Common.Converter.BoolToVisibilityConverter  	BoolToVis  BorderStyle �� 
TargetType �� Property �� Value  TextBoxStyle��%  &	        &	      &	 &     &	 9     &	 �       5   
   6@     5   
   6&     5   
   6,   �� 5   
   " ��6$   .�5      ��  � ��$ 1q�60   �� 5       � ��
 �   �6,   5      �� 5   
   " ��6%   .�5      ��  � ��$ 0q�60   5      5      .��5      �� $
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
��Auto �6    60    � ColumnDefinitions 5:      �� 5;      $	��250 �6#   61   �� 5<      $	��250 �6#   61   �� 5=      $��90 �6#   60   �� 5>      $	��180 �6#   61   �� 5?      $	��220 �6#   61   .+�5B      ]� $��0��6   $��0��6%   $��2��65   .+�5C      �� -   5        $��lblSupplierName��5C      $��Supplier Name��64   6L   �� 5E      -   5        $��cmbSupplierName��5E      $��42,2,0,0q�63   {�.  $	��212��5F      $��20��6)   $
��Left=�66   
���   � �� DisplayMemberPath$ SupplierName��5G   Q    �� SelectedValuePath$ ID��6r   $	��Top=�6�   ��5E   X   �� *LstSuppliers+ �� SelectedValue 5G   #   �� *SelectedSupplierID+.  (System.Windows.Interactivity.Interaction	   Triggers	 5H      /  )System.Windows.Interactivity.EventTrigger  5I      
   	EventName$
 SelectionChanged��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5J      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� *!SupplierSelectionChangedCommand+5K      5M      �� 5N      $��10,0,0,0q�6   �� 5O       �� Command 6   �� *%#DataContext.NavigateToClientCommand+ �� RelativeSource ��  �� AncestorType" >� �� CommandParameter 5P      �� *SelectedSupplierID+.�6F   .�5Q      �� $��Supplier Details��6"   $
��Wrap=�6:   5R      5S      5T      �� 5U      -   5        $��lblBlank��5U   5   $��0��6   $��2��6%   $�� ��6G   $��3��6O   6c   �� 5W      -   5        $��lblSupplierCreditNoteNo��5W   5   $��0��6   $��3��6%   $��Supplier Credit Note No.��6T   6w   �� 5X      -   5        $��txtSupplierCreditNoteNo��5X   \   $��0��6   $��4��6#   $	��212��63   $
��Left=�6?   $��5,0,0,0q�6{   ��5Y      �� *SupplierCreditNoteNo+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6k   ]� 5[      $��2��6   $��0��6&   $��2��66   $
��Left=�6J   .+�5\      �� -   5        $��lblDebitNoteDate��5\   9   $��1��6   $��3��6)   $��Debit Note Date��6Q   6k   (  "System.Windows.Controls.DatePicker  5]      -   5        $	��212��5]      $��25��6)   $��33,0,1,0q�65   {�.     SelectedDate 5^      �� *	DebitDate+ �� BindingGroupName$ Group1��$ PropertyChanged=�  5_      :	  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name �� 
IsReadOnly  BaseBorderBrush `� 	Converter �� Path��%�  '	        7   �� 5`      " 	 6    .�5a      ��  � �� 5b   "   �� 5c   &   .R�5d   *   �� $ PART_TextBox��62    . $��0q�6[   $��Stretch=�6o   $��Stretch=�5e   .   #���  6R   .��6�   ��5f   .   `� 5g   2   8   .1�5h   6   �� $ SelectedDate�6>   �� 5i   6   $ 
DateFormat�6>   6R   �� 5j   6   $ DataContext.DebitDate�6>    5k   A   �� "  5l   3   .��5m   <   5n   +   5o   '   5q      5r      5s      5t      5u      ]� 5w      $��1��6   $��0��6%   $��2��65   .+�5x      �� -   5        $��lblDebitNoteNo��5x      $��Debit Note No.��63   6L   �� 5y      $��40,2,0,0q�6   $��24��6-   $��1q�69   
���   �$	��212��6a   $
��Left=�5z      ._�5{      �� �� 5|      {�.  $
��Wrap=�6P   ��6$   �� *	DebitNo+6P   5�      5�      5�      �� 5�      -	   5        $!��lblSupplierCreditNoteAmount��5�   7   $��2��6   $��3��6'   $!��Supplier Credit Note Amount��6Z   6�   �� 5�      -
   5        $!��txtSupplierCreditNoteAmount��5�   ]   $	��212��6   $��2��6"   $��4��60   $
��Left=�6@   $��5,0,0,0q�6�   ��5�      �� *SupplierCreditNoteAmount+$ TwoWay=�$ PropertyChanged=�6q   �� 5�      -   5        $��lblSupplierCreditNoteDate��5�   8   $��1��6   $��3��6'   $��Supplier Credit Note Date��6Y   6|   ]� 5�      $��1��6   $��4��6%   .+�5�        -   5        $��SupplierCNDatepicker��5�      $��1��5�      $��4��6'   $	��212��68   $��5,0,0,0q�6D   $
��Left=�6U    5�   1   �� *SupplierCNDateCalender+$ Group1��$ PropertyChanged=�  5�      ��%�  '	        7   �� 5�      " 	 6   .�5�      ��  � �� 5�      �� 5�   "   .R�5�   &   �� $ PART_TextBox��6.    . $��0q�6W   $��Stretch=�6k   $��Stretch=�5�   .   $y�Hidden=�6R   #���  6f   .��6�   ��5�   *   `� 5�   .   8   .1�5�   2   �� $ SelectedDate�6:   �� 5�   2   $ 
DateFormat�6:   6N   �� 5�   2   $( "DataContext.SupplierCNDateCalender�6:    5�   A   �� "  5�   /   .��5�   8   5�   '   5�   #   5�      5�      5�      5�      �� 5�      -   5        $ PART_TextBox��5�   U   $��-265 -5 0 -5q�6   $��1��6,   $��21��69   $��3��6E    .  $��0 0 0 0q�6   $��Stretch=�6�   $��Stretch=�5�      $	��160��6�   ��65   �� $ SupplierCreditNoteDateStr�$ TwoWay=�$ PropertyChanged=�.��6�   5�      5�      �� 5�      $��3��6   $��0��6%   $��6��65   
�������$��Italic$�6[   ��To create a Debit Note, create a Purchase Invoice Total with minus value (Purchase Return), and Simple will automatically create a Debit Note.5�      ]� 5�      $��5��6   $��0��6%   $��2��65   $��0,0,0,2q�6I   .+�5�      �� -   5         ��Name$ btnAdjustDebitNote��5�      $��23��65   $	��Top=�6A   $
��auto��6`   $0��*Adjust Debit Note against Purchase Invoice��6m     ButtonStyle#���  6�   ��5�      �� *AdjustDebitNoteCommand+��6D   �� *	DebitNo+6k   �� 5�      $��OR��6   $��15,0,0,5q�6&   6:   �� 5�      -   5        $ btnCollectMoney��5�   %   $��23��6   $	��Top=�6>   $	��180��6^   $!��Collect money from Supplier��6j   #���  5�      $	��New��6s   ��6?   �� *!CollectMoneyFromSupplierCommand+6�   5�      � 5�      $	��985��6   $��6��6E   $��0��6R   $��5��6b   $��0,0,3,0q�6v   ��6    �� *PIFormGridHeight+.+�5�      � .+�5�      &
   System.Windows.Controls.DataGrid
  -   5         
 Name$ CustomGridLines��5�      $��0��6`    
  GridLinesVisibility$	 All=�5�   U    
  HorizontalGridLinesBrush
 ����� 
  VerticalGridLinesBrush
 ����� 
  AutoGenerateColumns .  $ 
  HorizontalScrollBarVisibility$ Hidden=�5�      "  
  VerticalScrollBarVisibility$  Disabled=�6C     BackHeaderStyle20! 
  ColumnHeaderStyle#! [ 5�      " 
  HeadersVisibility$	" All=�6R   $��0,0,0,0q�6j   ��5�   8   �� *BackGroundLines+��5�      �� # �� ElementName$# grdPandS��$ ActualHeight���6q   �� $# grdPandS��$ ActualWidth�$ 
  Columns$ 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn%   Header$%  ��61   &   Width5  /System.Windows.Controls.DataGridLengthConverter$	& 230 6U   1  +System.Windows.Controls.DataGridBoundColumn'   Binding' 6;   �� *Col0+6c     5�      $%  ��61   $	& 230 6U   ' 6;   �� *Col1+6c     5�      $%  ��61   $	& 110 6U   ' 6;   �� *Col2+6c     5�      $%  ��61   $	& 120 6U   ' 6;   �� *Col3+6c     5�      $%  ��61   $& 60 6U   ' 6;   �� *Col4+6b     5�      $%  ��61   $	& 145 6U   ' 6;   �� *Col4+6c     5�      $%  ��61   $& 88 6U   ' 6;   �� *Col4+6b   5�      
  5�      -   5        $��grdPandS��5�   3   $��8��6   $	 All=�6C   ( 
  
IsReadOnly( . $	��985��6o   $
��Left=�6{   $��1q�5�      
���   � .  ) 
  CanUserAddRows) . $��Disabled=�5�   O   * 
  CanUserReorderColumns* .  + 
  CanUserSortColumns+ . , 
  CanUserDeleteRows, . 
������ $
��Auto=�5�      ��.  ��5�   @   �� *PIFormGridHeight+$ 5�      4  .System.Windows.Controls.DataGridComboBoxColumn  5�      $	& 230 66   -   5        	chkPSCode��-   CanUserSort- . .   DisplayMemberPath$. PSCode��5�      /   SortMemberPath$/ PSCode��61   0   SelectedValuePath$0 ID��5�      1   SelectedValueBinding1 5�      �� *SelectedPSID+$ TwoWay=�$ PropertyChanged=�2   HeaderTemplate2 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   6B    5�   .   �� 5�   2   ��6C   �� $# 	chkPSCode��$ ActualWidth�.+�5�   .   ]� $��0��68   $��0��6E   .+�5�   2   �� $��txtHeaderPandScode��6<   �� 5�   "   $�Product & Service Code��6&   6J   5�   3   �� 5�   2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�   1   $��20��6<   $
��Left=�5�   ,   5�   /   5�   +   5�   '   3   ElementStyle3 5�   "   �� 5�   &   " ��6,   .�5�   *   ��  � �� 6H   �� $$ DataContext.ProductAndServices� �� " 
 5�   '   4   EditingElementStyle4 5�   "   �� 5�   &   " ��6,   .�5�   *   ��  � �� 6H   �� $$ DataContext.ProductAndServices� �� " 
 �� 5�   *    �@��
IsEditable . 6G   5�   '   5�        5�      $	& 230 65   -   5        	chkPSName��- . $. PSName��5      $/ PSName��61   $0 ID��5     1 5     �� *SelectedPSID+$ TwoWay=�$ PropertyChanged=�2 5  "   �� 5  &   .R�5  *   �  5  .   �� 5  2   6B    5	  .   �� 5
  2   ��6C   �� $# 	chkPSName��$ ActualWidth�.+�5  .   ]� $��0��68   $��0��6E   .+�5  2   �� $��txtHeaderPandSname��6<   �� 5  "   $�Product & Service Name��6&   6J   5  3   �� 5  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5  1   $��20��6<   $
��Left=�5  ,   5  /   5  +   5  '   3 5  "   �� 5  &   " ��6,   .�5  *   ��  � �� 6H   �� $$ DataContext.ProductAndServices� �� " 
 5  '   4 5  "   �� 5   &   " ��6,   .�5!  *   ��  � �� 6H   �� $$ DataContext.ProductAndServices� �� " 
 �� 5"  *    �@��
IsEditable . 6G   5$  '   5+       5-      	 HeaderStyle20Right5   HeaderStyle#5 [	 61   -   5        
txtQty��$/ PQQty��5-  s   $	& 110 6�   ' 6�   �� *PQQty+$ TwoWay=�$ 	LostFocus=�2 5.  "   �� 5/  &   .R�50  *   �  51  .   �� 52  2   6B    54  .   �� 55  2   ��6C   �� $# txtQty��$ ActualWidth�.+�57  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�58  2   �� �� 59  #   $�Quantity��6'   6:   �� 5:  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5;  1   $��20��6<   $
��Left=�5<  ,   5>  /   5?  +   5@  '   6   ElementStyle6 5G  "   �� 5H  &   " ��6,   .�5I  *   ��  � ��$ Right=�6P   5J  '   7   EditingElementStyle7 5L  "   �� 5M  &   " ��6,   .�5N  *   ��  �@��	MaxLength$ 5��6F   �� 5O  *    � ��$ Right=�6W   5P  '   5R       5S     #5 [	 61   -   5        Txtprice��$/ PQPrice��5S  v   $% Price��6�   $	& 120 6  ' 6�   �� *	PQPrice+8 �� StringFormat$8 
{0:0.####}��$ TwoWay=�$ 	LostFocus=�2 5Y  "   �� 5Z  &   .R�5[  *   �  5\  .   �� 5]  2   6B    5_  .   �� 5`  2   ��6C   �� $# Txtprice��$ ActualWidth�.+�5b  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5c  2   �� �� 5d  #   $�Price��6'   67   �� 5e  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5f  1   $��20��6<   $
��Left=�5g  ,   5h  /   5i  +   5j  '   6 5l  "   �� 5m  &   " ��6,   .�5n  *   ��  � ��$ Right=�6P   5o  '   7 5q  "   �� 5r  &   " ��6,   .�5s  *   ��  �@��	MaxLength$ 10��6F   �� 5t  *    � ��$ Right=�6W   5v  '   5y       5z     #5 [	 61   -   5        Txtdiscount��- .  $% Disc %��5{     $& 60 6�   9   SortDirection9 5z  x   Z� ' 5{  +   �� *
PQDiscount+$ TwoWay=�$ 	LostFocus=�$
8 {0}%��6 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   5�  '   7 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  �@��	MaxLength$ 10��6F   �� 5�  *    � ��$ Right=�6W   5�  '   5�       5�     #5 [	 61   -   5        	Txtamount��$/ PQAmountStr��5�  v   $% Amount��6�   $	& 145 6�   :   
IsReadOnly: . ' 6�   �� *PQAmountStr+2 5�  "   �� 5�  &   .R�5�  *   �  5�  .   �� 5�  2   6B    5�  .   �� 5�  2   ��6C   �� $# 	Txtamount��$ ActualWidth�.+�5�  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5�  2   �� �� 5�  #   $�Amount��6'   68   �� 5�  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�  1   $��20��6<   $
��Left=�5�  ,   5�  /   5�  +   5�  '   6 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   5�  '   5�       5�     -   5        
TxtTaxname��#5 [	 5�  E   $% 
Tax Rate %��5�  *   - .  $& 88 5�  )   : . 9 5�  >   Z� ' 5�  )   �� *
GSTRateStr+$ TwoWay=�$ PropertyChanged=�2 5�  "   �� 5�  &   .R�5�  *   � ; � IsSharedSizeScope; . ��6O   �� $# 
TxtTaxname��$ ActualWidth� 5�  .   �� 5�  2   6E   .+�5�  .   �� $��0��68   $��Right=�6H   �� 5�  2   �66   �� *DataContext.TaxName+ �� " >�6�    �� 5�  2   $�Rate %��67   6G   5�  /   5�  +   5�  '   6 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   5�  '   5�     5�     5�     5�     �� 5�     -   5        $��lblTotalBeforeTax��5�  I   $��7��6   $��2��6%   $��2��65   $��Total before Tax��6b   $��Center=�5�     $��90,0,0,0q�61   6F   �� 5�     -   5        $��txtTotalBeforeTax��5�  Z   $��7��6   $��3��6#   $��2��63   $��	162,5,0,0q�6G    . $
��Left=�6�   $��Right=�5�     
���������5�  �   �� $# 	Txtamount��$ ActualWidth���5�  I   �� *TotalBeforeTaxStr+$ TwoWay=�$ PropertyChanged=�6�   �� 5�     -   5        $��lblTax��5�  I   $��8��6   $��2��6%   $��2��65   $��90,0,0,0q�6q   $��Center=�6�   ��6W   �� *	TaxName+6�   �� 5�     -   5        $��txtTax��5�  Z   $��8��6   $��3��6#   $��2��63   $��	162,0,0,0q�6G    . 
�������$
��Left=�6�   $��Right=�5�     ��5�  �   �� $# 	Txtamount��$ ActualWidth���5�  7   �� *TotalTaxStr+$ TwoWay=�$ PropertyChanged=�6�   �� 5�     -   5        $��lblTotalAfterTax��5�  I   $��9��6   $��2��6%   $��2��65   $��90,0,0,0q�6b   $��Center=�6t   �� 5�     $�Total after Tax��6    �� 5�     �6   �� *CurrencyName+5�     �� 5�     -   5        $��txtTotalAfterTax��5�  Z   $��9��6   $��3��6#   $��2��63   $��	162,0,0,0q�6G    . 
�������$
��Left=�6�   $��Right=�5�     ��5�  �   �� $# 	Txtamount��$ ActualWidth���5�  3   �� *TotalAfterTaxStr+$ TwoWay=�$ PropertyChanged=�6�   �� 5�     -   5        $��lblTermsandConditions��5�  ]   $��7��6   $��0,10,0,0q�6&   $��2��68   $��0��6L   $��Terms and Conditions��6z   6�   ]� 5�     $��8��6   $��0��6%   $��2��65   $��2��6F   .+�5�     �� -    5        $ txtTermsandConditions��5�     $��65��69   $	��370��6G   $��0,0,0,0q�6T   < �� TextWrapping$
< Wrap=�5�  m   $
��Left=�6�   $	��Top=�6�    6   �� *AllFieldsReadonly+$ TwoWay=�$ PropertyChanged=���5�     �� *TermsAndConditions+$ TwoWay=�$ PropertyChanged=�6g   5�     �� 5�     $��200,-40,0,25q�6   $	��100��6/   $��Center=�5�     $
��Bold"�69   $��9��6M   $��1��6Z   $��2��6j   
���  ��= J� RenderTransformOrigin$= 0.668,0.529&�6�   $��2��6  $��26��6  y�6{   �� $ RubberStampDN�> �� 	Converter#> [ 
ADJUSTED6,  �� 5�     $��9��6   $��1��6>   $��Right=�6N   $	��100��6j   ��6!   �� *	ImgSource+6x   �� 5�     $��10��6   $��0��6&   �� 5�     $��10��6   $��3��6&   $��
-100 0 0 0q�66   $��3��6J   $��3��6^   
���  ��$
��Wrap=�6�   ��6�   �� $ 
DateErrors�$ TwoWay=�$ PropertyChanged=�6�   ]� 5�     $��10��6   $��2��6&   $��Right=�66   $	��Top=�6R   $��3��6j   $��0 0 3 0q�6~   .+�5�     �� -!   5        $ btnPrint��5�     $��Print��6+   $��	10,10,0,0q�6;   #���  6N   ��6t   �� *PrintClickCommand+$ TwoWay=���6�   �� $ DebitNo�6�   �� 5�     -"   5        $ btnSave��5�     $
��Save��6*   $��	10,10,0,0q�69   #���  6L   ��6r   �� *SaveCommand+6�   �� 5�     -#   5        $ btnClose��5�     $��Close��6+   $��	10,10,0,0q�6;   #���  6N   ��6t   �� *CloseCommand+6�   5�     5�     5�     5�     
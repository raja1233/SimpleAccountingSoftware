   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SDN.Purchasing.ViewSDN.Purchasing.View  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5
      0    *SDN.Purchasing.View.RefundFromSupplierView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:SDN.Purchasing.View     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5
      $
��1024��5	        � 	Resources  5      ,  &SDN.Common.Converter.DateTimeConverter   DateTimeFormatter.  (SDN.Common.Converter.RowToIndexConverter  RowToIndexConverter9  3SDN.Common.Converter.TextInputToVisibilityConverter " TextInputToVisibilityConverter  BorderStyle �� 
TargetType �� Property �� Value  TextBoxStyle  brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder��%�  &	        &	      &	 &     &	 9     &	 �     &	 �     &	     &	 *      5   
   6@     5   
   6&     5   
   61   �� 5   
   " ��6$   .�5      ��  � ��$ 1q�60   �� 5       � ��
 �   �6,   5      �� 5   
   " ��6%   .�5      ��  � ��$ 0q�60   5      �� 5   
   $ White��6;   �� 5   
   $
 Gray��6;   �� 5   
   $ Black��67   5      .��5      �� $
��Auto=�6   $
��Auto=�66   .��5   
   � $��
10,10,0,10q�6   $
��auto��6#   $
��auto��60     5         
ComboStyle��%#  '��       &	 �     �� 5!      " ��6   .�5"      ��  � ��$ 25��6/   6<   �� 5#       � ��$ 0,0,0,4q�6/   �� 5$       � ��
 �   �64   5%      �� 5&      " ��6+   .�5'      ��  � ��$ 0,0,0,4q�6/   �� 5(       � ��
 �   �64   5)      5*       � RowDefinitions 5+      �� 5,      6"   �� 5-      6"   �� 5.      6"   �� 5/      6"   �� 50      6"   �� 51      6"   �� 52      6"   �� 53      6"   �� 54      6"   �� 55      6"   �� 56      6"    � ColumnDefinitions 58      �� 59      $	��500 �6#   61   �� 5:      $	��500 �6#   61   .+�5=      ]� $��0��6   $��0��6%   .+�5>      �� -   5        $��lblSupplierName��5>      $��Supplier Name��64   $	��140��6I   6W   �� 5?      $��*��6   
���  ��$��0,0,0,0q�66   �� 5I      -   5        $��cmbSupplierName��5I      $��2,2,0,0q�63    �� 
IsEditable . $	��230��5J      $��25��6(   $
��Left=�65   #��[ 5K       �� DisplayMemberPath$ SupplierName��6p   	 �� SelectedValuePath$	 ID��6�   $	��Top=�6�   ��5I   V   �� *ListSuppliers+{�5J   P   �� *IsSupplierEnabled+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedValue 5K   B   �� *SelectedSupplierID+.  (System.Windows.Interactivity.Interaction   Triggers 5L      /  )System.Windows.Interactivity.EventTrigger  5M         	EventName$ SelectionChanged��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5N      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� *SelectChangedCommand+5O      5Q      5S      ]� 5T      $��0��6   $��0��6%   $��	130,0,0,0q�66   .+�5U      �� $��17 5 0 0q�6    	 WaterMarkStyle#��[	 62   $
��Left=�5V      $��Search��62   #��[ 6@   y�5W      `� 5X       `� 	Converter# [ 6'   .1�5Y      ��  �� ElementName$ cmbSupplierName��6&    �� Path$ Text.IsEmpty�6D   �� 5Z      $ cmbSupplierName��6&   $ 	IsFocused�6D   5[      5]      5^      ]� 5q      $��1��6   $��0��6%   .+�5r      �� $��Cash/Bank A/c Name��6   $	��140��67   $	��140��6F   $	��140��6U   6d   �� 5s      -   5        $��	cmbAcName��5s      $��7,0,0,5q�6-   $	��230��5t      $��25��6(   $
��Left=�65   
���   �$ AccountName��5u   P   $	 	AccountID��6p   $	��Top=�6�   ��5s   @   �� *AccountDetails+ 5u   #   �� *SelectedAccountID+ 5v        5w      $ SelectionChanged��6)   . 5x         64   �� *!SupplierSelectionChangedCommand+5y      5{      5|      ]� 5}      $��2��6   $��0��6%   .+�5~      �� $��Cash/Cheque No.��6   $	��140��63   6A   �� 5�      $��*��6   
���  ��$��0,0,2,0q�66   �� 5�      $	��230��6   $
��Left=�6&    �� 
IsReadOnly 6A   �� *IsTextBoxReadOnly+$
 TwoWay=�$ PropertyChanged=���6�   �� *CashChequeNo+$
 TwoWay=�$ PropertyChanged=�6�   5�      ]� 5�      $��2��6   $��1��6%   $��
-110 0 0 0q�65   .+�5�      �� 
�������$��Italic$�6.   =;For Cheque, Credit Card, etc., enter RS- followed by number6~   5�      ]� 5�      $��3��6   $��0��6%   .+�5�      �� -   5        $��lblDate��5�      $
��Date��6,   $	��140��68   $	��140��6G   $	��140��6V   6e   �� 5�      $��*��6   
���  ��$��0,0,2,0q�66   (  "System.Windows.Controls.DatePicker  5�      -   5        $��RefundDatepicker��5�      $	��230��5�      $	��230��6,   $
��Left=�6;   $��0,0,0,4q�6W   $	��230��5�   �      SelectedDate 6-   �� *RefundDateCalender+ �� BindingGroupName$ Group1��$ PropertyChanged=�  5�      :	  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name 
 BaseBorderBrush �� RelativeSource �� AncestorType��%�  '	        7   �� 5�      " 	 6    .�5�      ��  � �� 5�   "   �� 5�   &   .R�5�   *   �� $ Delivery_TextBox��62    . $��0q�6_   $��Stretch=�6s   $��Stretch=�5�   .   $y�Hidden=�6Q   #��� 
 6e   .��6�   ��5�   .   `� 5�   2   8   .1�5�   6   �� $ SelectedDate�6>   �� 5�   6   $ 
DateFormat�6>   6R   �� 5�   6   $$ DataContext.RefundDateCalender�6>    5�   A   �� "  5�   3   .��5�   <   5�   +   5�   '   5�      5�      5�      5�      �� 5�      -   5        $ PART_TextBox��5�   o   $��-420 -5 0 0q�6   $��21��6/   #��[ 6;    .  $��0 0 0 0q�6�   $��Stretch=�6�   $��Stretch=�5�      $	��160��6�   ��65   �� $ DateStr�$
 TwoWay=�$ PropertyChanged=�.��6�   5�      5�      ]� 5�      $��4��6   $��0��6%   .+�5�      �� $	��140��6   	Amount �� 5�      6*   5�      �� 5�      $��*��6   
���  ��$��0,0,2,0q�66   �� 5�      $	��230��6   $
��Left=�6q   ��6&   �� *	AmountStr+$
 TwoWay=�$ PropertyChanged=�6�   5�      ]� 5�      $��5��6   $��0��6%   .+�5�      �� $	��140��6   	Remarks5�      �� 5�      $	��230��6   $��7,0,0,0q�6&   $
��Left=�6�   ��67   �� *	Remarks+$
 TwoWay=�$ PropertyChanged=�6�   5�      ]� 5�      $��6��6   $��0��6%   $��2��65   .+�5�      �� 
�������$��Italic$�6.   omTo adjust a Cash/Cheque against 1 or more Purchase Orders/Debit Notes enter amounts in Amount Refunded Column5�      5�      �� 5�      $��7��6   $��0��6&   $	��Top=�66   $	��140��6N   $��25��6Z   $��	11,12,0,0q�6f   $
��Left=�5�      #��[	 63   $��Search��6\   #��[ 6j   y�5�      `� 5�      # [ 6#   .1�5�      �� $ cmbChequeNo��6"   $ Text.IsEmpty�6<   �� 5�      $ cmbChequeNo��6"   $ 	IsFocused�6<   5�      5�      �� 5�      -   5        $��cmbChequeNo��5�      $��7��5�      $��0��6%   $��6,10,0,0q�65   $	��140��5�   .   $��25��6:   $
��Left=�6G    . #��[ 5�      
������ $ 
PurchaseNo��6�   $	 
PurchaseNo��6�   $	��Top=�6�   {�5�   G   �� *SupplierEnabled+$
 TwoWay=�$ PropertyChanged=���6�   �� *PQDetailsEntityLst+ 5�   ]   �� *SelectedPurchaseNo+ 5�        5�      $ SelectionChanged��6%   . 5�         60   �� *PurchaseNoChangedCommand+5�      5�      �� 5�      $��8��6   $��0��6&   $��4��66   .+�5�      � .+�5�      &
   System.Windows.Controls.DataGrid
  -   5         
 Name$ CustomGridLines��5�      $��0��6`    
  GridLinesVisibility$	 All=�5�   P    
  HorizontalGridLinesBrush
 ����� 
  VerticalGridLinesBrush
 ����� 
  AutoGenerateColumns .  $ 
  HorizontalScrollBarVisibility$ Hidden=�5�      "  
  VerticalScrollBarVisibility$  Disabled=�6C     BackHeaderStyle41! 
  ColumnHeaderStyle#! [ 5�      " 
  HeadersVisibility$	" All=�6R   ��5�   8   �� *BackGroundLines+��5�      �� $	 dg1��$ ActualHeight���6l   �� $	 dg1��$ ActualWidth�# 
  Columns# 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn$   Header$$  ��61   %   Width5  /System.Windows.Controls.DataGridLengthConverter$	% 140 6U   1  +System.Windows.Controls.DataGridBoundColumn&   Binding& 6;   �� *Col0+6c     5�      $$  ��61   $	% 140 6U   & 6;   �� *Col1+6c     5�      $$  ��61   $	% 200 6U   & 6;   �� *Col3+6c     5�      $$  ��61   $	% 190 6U   & 6;   �� *Col4+6c     5�      $$  ��61   $% 90 6U   & 6;   �� *Col5+6b     5�      $$  ��61   $	% 214 6U   & 6;   �� *Col6+6c   5�      
  5�      -	   5        $	 dg1��5�   F   
������ $	��990��5�   9   $��Visible=�6E     HeaderStyle41#! [ 6x   $ Disabled=�5�   n   $	 All=�5�      $��1q�62   ' 
  CanUserAddRows' .  ( 
  CanUserDeleteRows( .  ) 
  SelectionMode$) Single=�5�   L   $	��Top=�6c    .  $��0,3,2,0q�6�   ��5�      �� *PQDetailsEntity+$
 TwoWay=�$ PropertyChanged=���6�   �� *PtSFGridHeight+$
 TwoWay=�$ PropertyChanged=�# 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      -
   5        
PurchaseNo��$	% 140 5�   J   *   MaxWidth$	* 140Q�6V   +   MinWidth$	+ 140Q�6e   $$ Purchase No��6u   ,   SortMemberPath$, 
PurchaseNo��6�   -   HeaderTemplate- 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   6B   �� 5�   2   5�   3    5�   .   �� 5�   2   ��6C   �� $ 
PurchaseNo��$ ActualWidth�.+�5�   .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5�   2   �� $
��Wrap=�6<   Purchase Order No.5�   3   �� 5�   2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�   1   $��20��6<   $
��Left=�5�   ,   5�   /   �� 5�   .   $��1��65   $��0��6B     
HeaderLine#��[ 6R   ._�5�   2   �� $��Debit Note No.��6<   $��1��6R   $��0��6_   $��Right=�6o   5�   /   5�   +   5�   '   .   CellTemplate. 5   "   �� 5  &   .R�5  *   �� �� 5  ,   / �� Command/ 66   �� *%#DataContext.NavigateToClientCommand+ �� " >�0 �� CommandParameter0 5  2   �� *
PurchaseNo+.�6Z   .�5  2   �� $
��Wrap=�6X   $
��None{�6l   ��6<   �� *
PurchaseNo+6l   5  .   5  *   5  '   5
       5     -   5        PurchaseDate��$	% 140 5  L   $	* 140Q�6X   $	+ 140Q�6g   $$ Purchase Date��6y   $, PurchaseDateStr��6�   - 5  "   �� 5  &   .R�5  *   �  5  .   �� 5  2   6B   �� 5  2   5  3    5  .   �� 5  2   ��6C   �� $ PurchaseDate��$ ActualWidth�.+�5  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5  2   �� $
��Wrap=�6<   Purchase Order Date5  3   �� 5  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5  1   $��20��6<   $
��Left=�5  ,   5  /   �� 5  .   $��1��65   $��0��6B   #��[ 6R   ._�5   2   �� $��Debit Note Date��6<   $��1��6S   $��0��6`   $��Right=�6p   5!  /   5"  +   5#  '   . 5%  "   �� 5&  &   .R�5'  *   �� $��Right=�6V   ��64   �� *PurchaseDateStr+5(  +   5)  '   5+       5M     -   5        PurchaseAmount��$	% 200 5M  M   $	* 200Q�6Y   $	+ 200Q�6h   $$ Purchase Amount��6x   $, PurchaseAmountStr��6�   - 5N  "   �� 5O  &   .R�5P  *   �  5Q  .   �� 5R  2   6B   �� 5S  2   5T  3    5V  .   �� 5W  2   ��6C   �� $ PurchaseAmount��$ ActualWidth�.+�5Y  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5Z  2   �� $
��Wrap=�6<   Purchase Order Amount5\  3   �� 5]  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5^  1   $��20��6<   $
��Left=�5_  ,   5`  /   �� 5a  .   $��1��65   $��0��6B   #��[ 6R   ._�5b  2   �� $��Debit Note Amount��6<   $��1��6U   $��0��6b   $��Right=�6r   5c  /   5d  +   5e  '   . 5g  "   �� 5h  &   .R�5i  *   �� $
��Wrap=�64   $
��None{�6H   $��Right=�6�   ��6_   �� *PurchaseAmountStr+5j  +   5k  '   5m       5n     -   5        	AmountDue��$	% 190 5n  H   $	* 190Q�6T   $	+ 190Q�6c   $$ 
Amount Due��6s   $, AmountDueStr��6�   - 5o  "   �� 5p  &   .R�5q  *   �  5r  .   �� 5s  2   6B   �� 5t  2   5u  3    5w  .   �� 5x  2   ��6C   �� $ 	AmountDue��$ ActualWidth�.+�5z  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5{  2   �� $
��Wrap=�6<   
Amount Due5}  3   �� 5~  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5  1   $��20��6<   $
��Left=�5�  ,   5�  /   �� 5�  .   $��1��65   $��0��6B   #��[ 6R   ._�5�  2   �� $�� ��6<   $��1��6E   $��0��6R   5�  /   5�  +   5�  '   . 5�  "   �� 5�  &   .R�5�  *   �� $��Right=�6R   $
��Wrap=�6n   $
��None{�6�   ��64   �� *AmountDueStr+5�  +   5�  '   5�       5�     -   5        Discount��$% 90 5�  �   $* 90Q�6�   $+ 90Q�6�   $$ Discount��6�   & 6C   �� *DiscountStr+$
 TwoWay=�$ PropertyChanged=�- 5�  "   �� 5�  &   .R�5�  *   �  5�  .   �� 5�  2   6B   �� 5�  2   5�  3    5�  .   �� 5�  2   ��6C   �� $ Discount��$ ActualWidth�.+�5�  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5�  2   �� #��z��6<   5�  3   �� 5�  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�  1   $��20��6<   $
��Left=�5�  ,   5�  /   �� 5�  .   $��1��65   $��0��6B   #��[ 6R   ._�5�  2   �� $�� ��6<   $��1��6E   $��0��6R   5�  /   5�  +   5�  '   1   ElementStyle1 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   5�  '   2   EditingElementStyle2 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6W   5�  '   5�       5�     -   5        txtAmountAdjusted��$	% 214 5�  -   $	* 214Q�69   $	+ 214Q�6I   $, AmountAdjustedStr��6X   & 5�  N   �� *AmountAdjustedStr+$
 TwoWay=�$ PropertyChanged=�- 5�  "   �� 5�  &   .R�5�  *   �  5�  .   �� 5�  2   6B   �� 5�  2   5�  3    5�  .   �� 5�  2   ��6C   �� $ txtAmountAdjusted��$ ActualWidth�.+�5�  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5�  2   �� $
��Wrap=�6=   Amount Refunded5�  3   �� 5�  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�  1   $��20��6<   $
��Left=�5�  ,   5�  /   �� 5�  .   $��1��65   $��0��6B   #��[ 6R   ._�5�  2   �� $�� ��6<   $��1��6E   $��0��6R   5�  /   5�  +   5�  '   1 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   5�  '   2 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6W   -   5        5�  '   5�     5�     5�     �� 5�     3 �� Orientation$3 
Horizontal=�6   $
��left=�67   $��5,0,0,0q�6R   .+�5�     � ��6   �� $ 
PurchaseNo��$ ActualWidth�.+�5�     ��   BorderStyleLeft#��[ 6!   ._�5�     �� $��Total��6)   $
��Bold"�66   6J   5�     5�     � 5�     ��6   �� $ PurchaseDate��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $�� ��6(   63   5�     5�     � 5�     ��6   �� $ PaymentDueDate��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $�� ��6(   63   5�     5�     � 5�     ��6   �� $ PurchaseAmount��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $��Right=�6J   $
��Bold"�6f   ��6(   �� *TotalSalesAmount+6z   5�     5�     � 5�     ��6   �� $ 	AmountDue��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     ��   DisplayTotalStyle#��[ 5�  (   ��5�  (   �� *TotalAmountDue+$
 TwoWay=�$ PropertyChanged=�5�  V   5      5     � 5     ��6   �� $ Discount��$ ActualWidth�.+�5     ��   BorderStyleRight#��[ 6!   ._�5     �� $�� ��6(   64   5     5     � 5     ��6   �� $ txtAmountAdjusted��$ ActualWidth�.+�5     �� #��[ 6!   ._�5	     �� #��[ 5
  (   ��5	  (   �� *TotalAmountPaid+$
 TwoWay=�$ PropertyChanged=�5
  U   5     5     5     5     ]� 5     $��10��6   $��0��6&   $��2��66   $��Bottom=�6J   .+�5     �� 
�������$��Italic$�6.   VTTotal of Amount Refunded column must be equal to Cash/Cheque Amount. Amounts are in �� 5  k   ��6u   �� *CurrencyName+6�   5     5     �� 5     $��9��6   $��1��6%   $��4��65   $��10,0,0,0q�6I   
���  ����6l   �� $ 
DateErrors�$
 TwoWay=�$ PropertyChanged=�6�   ]� 5     $��10��6   $��2��6&   $��Right=�66   $��Bottom=�6R   $��3��6m   $��0 0 3 0q�6�   .+�5     �� -   5        4 ��Name$4 btnNew��5     $	��New��6)   $��10,5,0,0q�67     ButtonStyle#���  6I   $	��New��6�   ��6o   �� *NewPSCommand+6�   �� 5     -   5        $4 btnSave��5     $
��Save��6*   $��10,5,0,0q�69   #���  6K   ��6q   �� *SaveCommand+6�   �� 5     -   5        $4 btnClose��5     $��Close��6+   $��10,5,0,0q�6;   #���  6M   ��6s   �� $ CloseCommand�6�   5     5!     5"     5#     
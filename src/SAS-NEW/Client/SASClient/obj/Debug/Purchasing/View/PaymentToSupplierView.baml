   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SDN.Purchasing.ViewSDN.Purchasing.View  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5
      /    )SDN.Purchasing.View.PaymentToSupplierView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:SDN.Purchasing.View     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5
      $
��1024��5      $
��auto��5        � 	Resources  5      ,  &SDN.Common.Converter.DateTimeConverter   DateTimeFormatter.  (SDN.Common.Converter.RowToIndexConverter  RowToIndexConverter9  3SDN.Common.Converter.TextInputToVisibilityConverter " TextInputToVisibilityConverter  BorderStyle �� 
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
���  ��$��0,0,0,0q�66   �� 5I      -   5        $��cmbSupplierName��5I       �� 
IsEditable . $��2,2,0,0q�6E   $	��230��5J      $��25��6(   $
��Left=�65   #��[ 5K       �� DisplayMemberPath$ SupplierName��6�   	 �� SelectedValuePath$	 ID��6�   $	��Top=�6�   ��5I   W   �� *ListSuppliers+{�5J   P   �� *IsSupplierEnabled+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedValue 5K   B   �� *SelectedSupplierID+$ PropertyChanged=�.  (System.Windows.Interactivity.Interaction   Triggers 5L      /  )System.Windows.Interactivity.EventTrigger  5M         	EventName$ SelectionChanged��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5N      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� *SelectChangedCommand+5O      5Q      5S      ]� 5T      $��0��6   $��0��6%   $��2��65   $��	130,0,0,0q�6I   .+�5U      �� $��17 5 0 0q�6    	 WaterMarkStyle#��[	 62   $
��Left=�5V      $��Search��62   #��[ 6@   y�5W      `� 5X       `� 	Converter# [ 6'   .1�5Y      ��  �� ElementName$ cmbSupplierName��6&    �� Path$ Text.IsEmpty�6D   �� 5Z      $ cmbSupplierName��6&   $ 	IsFocused�6D   5[      5]      5^      ]� 5q      $��1��6   $��0��6%   .+�5r      �� $��Cash/Bank A/c Name��6   $	��140��67   $	��140��6F   $	��140��6U   6d   �� 5s      -   5        $��	cmbAcName��5s      $��7,3,0,2q�6-   $	��230��5t      $��25��6(   $
��Left=�65   
���   �$ AccountName��5u   P   $	 	AccountID��6p   $	��Top=�6�   ��5s   @   �� *AccountDetails+ 5u   #   �� *SelectedAccountID+ 5v        5w      $ SelectionChanged��6)   . 5x         64   �� *!SupplierSelectionChangedCommand+5y      5{      5|      ]� 5}      $��2��6   $��0��6%   .+�5~      �� $��Cash/Cheque No.��6   $	��140��64   6B   �� 5�      $��*��6   
���  ��$��0,0,2,0q�66   �� 5�      $	��230��6   $
��Left=�6&    �� 
IsReadOnly 6A   �� *IsTextBoxReadOnly+$
 TwoWay=�$ PropertyChanged=���6�   �� *CashChequeNo+$
 TwoWay=�$ PropertyChanged=�6�   5�      ]� 5�      $��2��6   $��1��6%   $��
-110 0 0 0q�65   .+�5�      �� 
�������$��Italic$�6.   =;For Cheque, Credit Card, etc., enter PS- followed by number6~   5�      ]� 5�      $��3��6   $��0��6%   .+�5�      �� -   5        $��lblDate��5�      $
��Date��6,   $	��140��68   $	��140��6G   $	��140��6V   6e   �� 5�      $��*��6   
���  ��$��0,0,2,0q�66   (  "System.Windows.Controls.DatePicker  5�      -   5        $��PayToSupDatepicker��5�      $	��230��5�      $	��230��6,   $
��Left=�6;   $��0,0,0,4q�6W   $	��230��5�   �      SelectedDate 6/   �� *PayToSupDateCalender+ �� BindingGroupName$ Group1��$ PropertyChanged=�  5�      :	  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name 
 BaseBorderBrush �� RelativeSource �� AncestorType��%�  '	        7   �� 5�      " 	 6    .�5�      ��  � �� 5�   "   �� 5�   &   .R�5�   *   �� $ Delivery_TextBox��62    . $��0q�6_   $��Stretch=�6s   $��Stretch=�5�   .   #��� 
 6R   .��6�   ��5�   .   `� 5�   2   8   .1�5�   6   �� $ SelectedDate�6>   �� 5�   6   $ 
DateFormat�6>   6R   �� 5�   6   $&  DataContext.PayToSupDateCalender�6>    5�   A   �� "  5�   3   .��5�   <   5�   +   5�   '   5�      5�      5�      5�      �� 5�      -   5        $ PART_TextBox��5�   o   $��-420 -5 0 0q�6   $��21��6/   #��[ 6;    .  $��0 0 0 0q�6�   $��Stretch=�6�   $��Stretch=�5�      $	��160��6�   ��65   �� $ DateStr�$
 TwoWay=�$ PropertyChanged=�.��6�   5�      5�      ]� 5�      $��4��6   $��0��6%   .+�5�      �� $	��140��6   	Amount �� 5�      6*   5�      �� 5�      $��*��6   
���  ��$��0,0,2,0q�66   �� 5�      $	��230��6   $
��Left=�6q   ��6&   �� *	AmountStr+$
 TwoWay=�$ PropertyChanged=�6�   5�      ]� 5�      $��5��6   $��0��6%   .+�5�      �� $	��140��6   	Remarks5�      �� 5�      $	��230��6   $��7,0,0,0q�6&   $
��Left=�6�   ��67   �� *	Remarks+$
 TwoWay=�$ PropertyChanged=�6�   5�      ]� 5�      $��6��6   $��0��6%   $��2��65   .+�5�      �� 
�������$��Italic$�6.   vtTo adjust a Cash/Cheque against 1 or more Purchase Orders/Purchase Invoices enters amounts in Amount Adjusted Column5�      5�      �� 5�      $��7��6   $��0��6&   $	��Top=�66   $	��140��6N   $��25��6Z   $��11,8,0,0q�6f   $
��Left=�5�      #��[	 63   $��Search��6\   #��[ 6j   y�5�      `� 5�      # [ 6#   .1�5�      �� $ cmbChequeNo��6"   $ Text.IsEmpty�6<   �� 5�      $ cmbChequeNo��6"   $ 	IsFocused�6<   5�      5�      �� 5�      -   5        $��cmbChequeNo��5�      $��7��5�      $��0��6%   $��6,5,0,0q�65   $	��140��5�   -   $��25��69   $
��Left=�6F    . #��[ 5�      
������ $ 
PurchaseNo��6�   $	 
PurchaseNo��6�   $	��Top=�6�   {�5�   F   �� *SupplierEnabled+$
 TwoWay=�$ PropertyChanged=���6�   �� *PQDetailsEntityLst+ 5�   \   �� *SelectedPurchaseNo+ 5�        5�      $ SelectionChanged��6%   . 5�         60   �� *PurchaseNoChangedCommand+5�      5�      �� 5�      $��8��6   $��0��6&   $��4��66   .+�5�      � .+�5�      &
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
  Columns# 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn$   Header$$  ��61   %   Width5  /System.Windows.Controls.DataGridLengthConverter$	% 140 6U   1  +System.Windows.Controls.DataGridBoundColumn&   Binding& 6;   �� *Col0+6c     5�      $$  ��61   $	% 140 6U   & 6;   �� *Col1+6c     5�      $$  ��61   $	% 140 6U   & 6;   �� *Col2+6c     5�      $$  ��61   $	% 160 6U   & 6;   �� *Col3+6c     5�      $$  ��61   $	% 140 6U   & 6;   �� *Col4+6c     5�      $$  ��61   $% 90 6U   & 6;   �� *Col5+6b     5�      $$  ��61   $	% 164 6U   & 6;   �� *Col6+6c   5�      
  5�      -	   5        $	 dg1��5�   F   
������ $	��990��5�   9   $��Visible=�6E     HeaderStyle41#! [ 6x   $ Disabled=�5�   n   $	 All=�5�      $��1q�62   ' 
  CanUserAddRows' .  $��0,3,2,0q�6k   ( 
  CanUserDeleteRows( .  ) 
  SelectionMode$) Single=�5�   L   $	��Top=�6c    .  ��5�      �� *PQDetailsEntity+$
 TwoWay=�$ PropertyChanged=���6�   �� *PtSFGridHeight+$
 TwoWay=�$ PropertyChanged=�# 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      -
   5        
PurchaseNo��$	% 140 5�   J   *   MaxWidth$	* 140Q�6V   +   MinWidth$	+ 140Q�6e   $$ Purchase No��6u   ,   SortMemberPath$, 
PurchaseNo��6�   -   HeaderTemplate- 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   6B   �� 5�   2   5�   3    5�   .   �� 5�   2   ��6C   �� $ 
PurchaseNo��$ ActualWidth�.+�5�   .   ]� $��0��68   $��0��6E   .+�5�   2   �� $
��Wrap=�6<   Purchase Order No.5�   3   �� 5�   2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�   1   $��20��6<   $
��Left=�5�   ,   5�   /   �� 5�   .   $��1��65   $��0��6B     
HeaderLine#��[ 6R   ._�5�   2   �� $��Purchase Invoice No.��6<   $��1��6X   $��0��6e   5�   /   5�   +   5   '   .   CellTemplate. 5  "   �� 5  &   .R�5  *   �� �� 5  ,   / �� Command/ 66   �� *%#DataContext.NavigateToClientCommand+ �� " >�0 �� CommandParameter0 5  2   �� *
PurchaseNo+.�6Z   .�5  2   �� $
��Wrap=�6X   $
��None{�6l   ��6<   �� *
PurchaseNo+6l   5  .   5	  *   5
  '   5       5     -   5        PurchaseDate��$	% 140 5  L   $	* 140Q�6X   $	+ 140Q�6g   $$ Purchase Date��6y   $, PurchaseDateStr��6�     HeaderStyle41Right1   HeaderStyle#1 [ 6�   - 5  "   �� 5  &   .R�5  *   �  5  .   �� 5  2   6B   �� 5  2   5  3    5  .   �� 5  2   ��6C   �� $ PurchaseDate��$ ActualWidth�.+�5  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5  2   �� $
��Wrap=�6<   Purchase Order Date5  3   �� 5  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5  1   $��20��6<   $
��Left=�5  ,   5   /   �� 5!  .   $��1��65   $��0��6B   #��[ 6R   ._�5"  2   �� $��Right=�6<   $��Purchase Invoice Date��6X   $��1��6u   $��0��6�   5#  /   5$  +   5%  '   . 5'  "   �� 5(  &   .R�5)  *   �� $��Right=�6V   ��64   �� *PurchaseDateStr+5*  +   5+  '   5-       5.     #1 [ 65   -   5        PaymentDueDate��$	% 140 5.     $	* 140Q�6�   $	+ 140Q�6�   $$ Payment Due Date��6�   $, PaymentDueDateStr��6�   - 5/  "   �� 50  &   .R�51  *   �  52  .   �� 53  2   6B   �� 54  2   55  3    57  .   �� 58  2   ��6C   �� $ PaymentDueDate��$ ActualWidth�.+�5:  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5;  2   �� $
��Wrap=�6<   Payment Due Date5=  3   �� 5>  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5?  1   $��20��6<   $
��Left=�5@  ,   5A  /   �� 5B  .   $��1��65   $��0��6B   #��[ 6R   ._�5C  2   �� $�� ��6<   $��1��6E   $��0��6R   5D  /   5E  +   5F  '   . 5H  "   �� 5I  &   .R�5J  *   �� $��Right=�6W   ��64   �� *PaymentDueDateStr+5K  +   5L  '   5N       5O     #1 [ 65   -   5        PurchaseAmount��$	% 160 5O     $	* 160Q�6�   $	+ 160Q�6�   $$ Purchase Amount��6�   $, PurchaseAmountStr��6�   - 5P  "   �� 5Q  &   .R�5R  *   �  5S  .   �� 5T  2   6B   �� 5U  2   5V  3    5X  .   �� 5Y  2   ��6C   �� $ PurchaseAmount��$ ActualWidth�.+�5[  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5\  2   �� $
��Wrap=�6<   Purchase Order Amount5^  3   �� 5_  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5`  1   $��20��6<   $
��Left=�5a  ,   5b  /   �� 5c  .   $��1��65   $��0��6B   #��[ 6R   ._�5d  2   �� $��Right=�6<   $��Purchase Invoice Amount��6X   $��1��6w   $��0��6�   5e  /   5f  +   5g  '   . 5i  "   �� 5j  &   .R�5k  *   �� $
��Wrap=�64   $
��None{�6H   $��Right=�6�   ��6_   �� *PurchaseAmountStr+5l  +   5m  '   5o       5p     #1 [ 65   -   5        	AmountDue��$	% 140 5p  z   $	* 140Q�6�   $	+ 140Q�6�   $$ 
Amount Due��6�   $, AmountDueStr��6�   - 5q  "   �� 5r  &   .R�5s  *   �  5t  .   �� 5u  2   6B   �� 5v  2   5w  3    5y  .   �� 5z  2   ��6C   �� $ 	AmountDue��$ ActualWidth�.+�5|  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5}  2   �� $
��Wrap=�6<   
Amount Due5  3   �� 5�  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�  1   $��20��6<   $
��Left=�5�  ,   5�  /   �� 5�  .   $��1��65   $��0��6B   #��[ 6R   ._�5�  2   �� $�� ��6<   $��1��6E   $��0��6R   5�  /   5�  +   5�  '   . 5�  "   �� 5�  &   .R�5�  *   �� $��Right=�6R   $
��Wrap=�6n   $
��None{�6�   ��64   �� *AmountDueStr+5�  +   5�  '   5�       5�     #1 [ 61   -   5        Discount��$% 90 5�  �   $* 90Q�6�   $+ 90Q�6�   $$ Discount��6�   & 6u   �� *DiscountStr+$
 TwoWay=�$ PropertyChanged=�- 5�  "   �� 5�  &   .R�5�  *   �  5�  .   �� 5�  2   6B   �� 5�  2   5�  3    5�  .   �� 5�  2   ��6C   �� $ Discount��$ ActualWidth�.+�5�  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5�  2   �� #��z��6<   5�  3   �� 5�  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�  1   $��20��6<   $
��Left=�5�  ,   5�  /   �� 5�  .   $��1��65   $��0��6B   #��[ 6R   ._�5�  2   �� $�� ��6<   $��1��6E   $��0��6R   5�  /   5�  +   5�  '   2   ElementStyle2 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   5�  '   3   EditingElementStyle3 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6W   5�  '   5�       5�     #1 [ 61   -   5        txtAmountAdjusted��$	% 164 5�  -   $	* 164Q�69   $	+ 164Q�6I   $, AmountAdjustedStr��6X   & 5�  ~   �� *AmountAdjustedStr+$
 TwoWay=�$ PropertyChanged=�- 5�  "   �� 5�  &   .R�5�  &   �  5�  *   �� 5�  .   6>   �� 5�  .   5�  /    5�  *   �� 5�  .   ��6?   �� $ txtAmountAdjusted��$ ActualWidth�.+�5�  *   ]� $��0��64   $��0��6A   $��Right=�6Q   .+�5�  .   �� $
��Wrap=�68   Amount Adjusted5�  /   �� 5�  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�  1   $��20��6<   $
��Left=�5�  ,   5�  +   �� 5�  *   $��1��61   $��0��6>   #��[ 6N   ._�5�  .   �� $�� ��68   $��1��6A   $��0��6N   5�  +   5�  '   5�  '   2 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   5�  '   3 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6W   -   5        5�  '   5�     5�     5�     �� 5�     4 �� Orientation$4 
Horizontal=�6   $
��left=�67   $��5,0,0,0q�6R   .+�5�     � ��6   �� $ 
PurchaseNo��$ ActualWidth�.+�5�     ��   BorderStyleLeft#��[ 6!   ._�5�     �� $��Total��6)   $
��Bold"�66   6J   5�     5�     � 5�     ��6   �� $ PurchaseDate��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $�� ��6(   63   5�     5�     � 5�     ��6   �� $ PaymentDueDate��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $�� ��6(   63   5�     5�     � 5�     ��6   �� $ PurchaseAmount��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $��Right=�6J   $
��Bold"�6f   ��6(   �� *TotalSalesAmount+6z   5�     5�     � 5�     ��6   �� $ 	AmountDue��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     ��   DisplayTotalStyle#��[ 5   (   ��5�  (   �� *TotalAmountDue+$
 TwoWay=�$ PropertyChanged=�5   V   5     5     � 5     ��6   �� $ Discount��$ ActualWidth�.+�5     ��   BorderStyleRight#��[ 6!   ._�5     �� $�� ��6(   64   5     5     � 5     ��6   �� $ txtAmountAdjusted��$ ActualWidth�.+�5	     �� #��[ 6!   ._�5
     �� #��[ 5  (   ��5
  (   �� *TotalAmountPaid+$
 TwoWay=�$ PropertyChanged=�5  U   5     5     5     5     ]� 5     $��10��6   $��0��6&   $��2��66   $��Bottom=�6J   .+�5     �� 
�������$��Italic$�6.   VTTotal of Amount Adjusted column must be equal to Cash/Cheque Amount. Amounts are in �� 5  k   ��6u   �� *CurrencyName+6�   5     5     �� 5     $��9��6   $��1��6%   $��4��65   $��	200,0,0,0q�6I   
���  ����6m   �� $ 
DateErrors�$
 TwoWay=�$ PropertyChanged=�6�   ]� 5     $��10��6   $��2��6&   $��Right=�66   $��Bottom=�6R   $��3��6m   $��0 0 3 0q�6�   .+�5     �� -   5        5 ��Name$5 btnNew��5     $	��New��6)   $��	10,10,0,0q�67     ButtonStyle#���  6J   ��6p   �� *NewPSCommand+6�   �� 5     -   5        $5 btnSave��5     $
��Save��6*   $��	10,10,0,0q�69   #���  6L   ��6r   �� *SaveCommand+6�   �� 5     -   5        $5 btnClose��5     $��Close��6+   $��	10,10,0,0q�6;   #���  6N   ��6t   �� *CloseCommand+6�   5     5      5!     5"     
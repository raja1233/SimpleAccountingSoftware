   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SDN.Purchasing.ViewSDN.Purchasing.View  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5
      1    +SDN.Purchasing.View.AdjustDebitNoteFormView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:SDN.Purchasing.View     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5
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
 �   �64   5)      5*       � RowDefinitions 5+      �� 5,      6"   �� 5-      6"   �� 5.      6"   �� 5/      6"   �� 50      6"   �� 51      6"   �� 52      6"   �� 53      6"    � ColumnDefinitions 55      �� 56      $	��500 �6#   61   �� 57      $	��500 �6#   61   .+�5:      ]� $��0��6   $��0��6%   .+�5;      �� -   5        $��lblSupplierName��5;      $��Supplier Name��64   6K   �� 5O      $��58,0,0,0q�6   {�.  $	��230��6>   $
��Left=�6�   ��6J   �� *SelectedSupplierName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5R      ]� 5S      $��0��6   $��1��6%   $��90,0,0,0q�65   .+�5T      �� $��Adjust Debit Note No��6   $	��143��69   $	��143��6H   $	��143��6W   6f   �� 5V      $��30,0,0,0q�6   	 �� 
IsReadOnly	 . $	��230��6>   $
��Left=�6�   ��6J   �� *AdjustDebitNoteNumber+$ TwoWay=�$ PropertyChanged=�6�   5W      �� 5c      -   5        $��lblBlank��5c   5   $��0��6   $��2��6%   $�� ��6G   $��3��6O   6c   ]� 5f      $��1��6   $��0��6%   .+�5g      �� $��Debit Note No��6   $	��143��62   $	��143��6A   $	��143��6P   6_   �� 5q      $��0,4,0,0q�6   {�.  $	��230��6=   $
��Left=�6�   ��6I   �� *DebitNoteNo+$ TwoWay=�$ PropertyChanged=�6�   5s      �� 5t      -   5        $��lblJournalDate��5t   Z   $��Adjust Debit Date��6   $��1��61   $��1��6>   $	��120��6N   $��90,0,0,0q�6q   5u      ]� 5v      $��	260 4 0 0q�6   $	��260��6,   $��1��68   $��1��6E   .+�5x      (  "System.Windows.Controls.DatePicker  -   5        $��AdjustDebitdDatePicker��5x      $��26��6;   $	��230��6G   $	��230��6V   $
��Left=�6e   $��3,0,0,0q�6�   $	��Top=�5z   �   
   SelectedDate
 6   �� *AdjustDebitDateCalender+ �� BindingGroupName$ Group1��$ PropertyChanged=�  5{      :  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name 	 BaseBorderBrush `� 	Converter �� Path �� RelativeSource �� AncestorType��%�  '        7   �� 5|      "  6    .�5}      ��  � �� 5~   "   �� 5   &   .R�5�   *   �� $ Date_TextBox��62   	 . $��0q�6[   $��Stretch=�6o   $��Stretch=�5�   .   #��� 	 6R   .��6�   ��5�   .   `� 5�   2   8   .1�5�   6   �� $ SelectedDate�6>   �� 5�   6   $ 
DateFormat�6>   6R   �� 5�   6   $) #DataContext.AdjustDebitDateCalender�6>    5�   A   �� "  5�   3   .��5�   <   5�   +   5�   '   5�      5�      5�      5�      �� 5�      -   5        $ PART_TextBox��5�   o   $��-322 -1 0 0q�6   $��22��6/   #��[ 6;   	 .  $��0q�6�   $��Stretch=�6�   $��Stretch=�5�      $	��160��6�   ��65   �� $ AdjustDebitNoteDateStr�$ TwoWay=�$ PropertyChanged=�.��6�   5�      5�      ]� 5�      $��2��6   $��0��6%   .+�5�      �� -   5        $��lblDate��5�      $��Debit Note Date��6,   $	��143��6C   $	��143��6R   $	��143��6a   6p     5�      -   5        {�.  $	��230��5�   /   $	��230��6>   $
��Left=�6M   $��0,4,0,4q�6i   $	��230��5�   r   
 6   �� *Date+$ Group1��$ PropertyChanged=�  5�      ��%�  '        7   �� 5�      "  6    .�5�      ��  � �� 5�   "   �� 5�   &   .R�5�   *   �� $ Delivery_TextBox��62   	 . $��0q�6_   $��Stretch=�6s   $��Stretch=�5�   .   #��� 	 6R   .��6�   ��5�   .   `� 5�   2   8   .1�5�   6   �� $ SelectedDate�6>   �� 5�   6   $ 
DateFormat�6>   6R   �� 5�   6   $ DataContext.Date�6>    5�   A   �� "  5�   3   .��5�   <   5�   +   5�   '   5�      5�      5�      5�      5�      ]� 5�      $��3��6   $��0��6%   .+�5�      �� $	��143��6   Debit Note Amount �� 5�   '   64   5�      �� 5�      {�.  $	��230��6,   $
��Left=�6�   ��68   �� *	AmountStr+$ TwoWay=�$ PropertyChanged=�6�   5�      ]� 5�      $��4��6   $��0��6%   $��2��65   .+�5�      �� 
�������$��Italic$�6.   nlTo adjust a Debit Note against 1 or more Purchase Purchase Invoices enters amounts in Amount Adjusted Column5�      5�      �� 5�      $��5��6   $��0��6&   $	��Top=�66   $	��140��6N   $��25��6Z   $��11,8,0,0q�6f   $
��Left=�5�       
 WaterMarkStyle#��[
 63   $��Search��6\   #��[ 6j   y�5�      `� 5�      # [ 6#   .1�5�      ��  �� ElementName$ cmbChequeNo��6"   $ Text.IsEmpty�6<   �� 5�      $ cmbChequeNo��6"   $ 	IsFocused�6<   5�      5�      �� 5�      -   5        $��cmbChequeNo��5�      $��5��5�      $��0��6%   $��6,5,0,0q�65   $	��160��5�   .   $��25��6:   $
��Left=�6G    �� 
IsEditable . #��[ 5�      
������  �� DisplayMemberPath$ 
PurchaseNo��6�    �� SelectedValuePath$ 
PurchaseNo��6�   $	��Top=�6�   {�5�   F   �� *SupplierEnabled+$ TwoWay=�$ PropertyChanged=���6�   �� *PQDetailsEntityLst+ �� SelectedValue 5�   [   �� *SelectedPurchaseNo+.  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ SelectionChanged��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�      6	  0System.Windows.Interactivity.InvokeCommandAction	   	  Command 60   �� *PurchaseNoChangedCommand+5�      5�      �� 5�      $��5��6   $��0��6&   $��4��66   .+�5�      � .+�5�      &
   System.Windows.Controls.DataGrid
  -	   5         
 Name$ CustomGridLines��5�      $��0��6`    
  GridLinesVisibility$	 All=�5�   P    
  HorizontalGridLinesBrush
 ����� 
  VerticalGridLinesBrush
 ����� 
  AutoGenerateColumns .  $ 
  HorizontalScrollBarVisibility$ Hidden=�5�      "  
  VerticalScrollBarVisibility$  Disabled=�6C     BackHeaderStyle20! 
  ColumnHeaderStyle#! [ 5�      " 
  HeadersVisibility$	" All=�6R   $��0,33,2,0q�6j   ��5�   8   �� *BackGroundLines+��5�      �� $	 dg1��$ ActualHeight���6l   �� $	 dg1��$ ActualWidth�# 
  Columns# 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn$   Header$$  ��61   %   Width5  /System.Windows.Controls.DataGridLengthConverter$	% 160 6U   1  +System.Windows.Controls.DataGridBoundColumn&   Binding& 6;   �� *Col0+6c     5�      $$  ��61   $	% 160 6U   & 6;   �� *Col1+6c     5�      $$  ��61   $	% 160 6U   & 6;   �� *Col2+6c     5�      $$  ��61   $	% 160 6U   & 6;   �� *Col3+6c     5�      $$  ��61   $	% 160 6U   & 6;   �� *Col4+6c     5�      $$  ��61   $	% 174 6U   & 6;   �� *Col5+6c   5�      
  5�      -
   5        $	 dg1��5�   F   
������ $	��990��5�   9   $��Visible=�6E   $ Disabled=�5�   >   $	 All=�5�      $��1q�62   ' 
  CanUserAddRows' .    HeaderStyle20#! [ 5�   /   ( 
  CanUserDeleteRows( .  ) 
  SelectionMode$) Single=�6~   $	��Top=�6�    .  $��0,33,2,0q�6�   * 
  
IsReadOnly* 5�   x   �� *EditDatagrid+��5�      �� *PQDetailsEntity+��6i   �� *PtSFGridHeight+# 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      -   5        
PurchaseNo��$	% 160 5�   J   +   MaxWidth$	+ 160Q�6V   ,   MinWidth$	, 160Q�6e   $$ Purchase No��6u   -   SortMemberPath$- 
PurchaseNo��6�   .   HeaderTemplate. 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   6B    5�   .   �� 5�   2   $
��auto �6C   �� 5�   2   $��10 �6D   .+�5�   .   ]� $��0��68   $��0��6E   .+�5�   2   �� $��Purchase Invoice No.��6<   $��1��6X   $��0��6e   �� 5�   2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�   1   $��20��6<   $
��Left=�5�   ,   5�   /   5�   +   5�   '   /   CellTemplate/ 5�   "   �� 5�   &   .R�5�   *   �� �� 5�   ,   0 �� Command0 66   �� *%#DataContext.NavigateToClientCommand+ �� " >�1 �� CommandParameter1 5   2   �� *
PurchaseNo+.�6Z   .�5  2   �� $
��Wrap=�6X   $
��None{�6l   ��6<   �� *
PurchaseNo+6l   5  .   5  *   5  '   5       5     -   5        PurchaseDate��$	% 160 5  K   $	+ 160Q�6W   $	, 160Q�6f   $$ Purchase Date��6w   $- PurchaseDateStr��6�   . 5  "   �� 5	  &   .R�5
  *   �  5  .   �� 5  2   5  3    5  .   �� 5  2   $
��auto �6C   �� 5  2   $��10 �6D   .+�5  .   ]� $��0��68   $��0��6E   .+�5  2   �� $��Purchase Invoice Date��6<   �� 5  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5  1   $��20��6<   $
��Left=�5  ,   5  /   5  +   5  '   / 5  "   �� 5   &   .R�5!  *   �� ��64   �� *PurchaseDateStr+5"  +   5#  '   5%       5&     -   5        PaymentDueDate��$	% 160 5&  N   $	+ 160Q�6Z   $	, 160Q�6i   $$ Payment Due Date��6y   $- PaymentDueDateStr��6�   . 5'  "   �� 5(  &   .R�5)  *   �  5*  .   �� 5+  2   6B    5.  .   �� 5/  2   $
��auto �6C   �� 50  2   $��10 �6D   .+�52  .   ]� $��0��68   $��0��6E   .+�53  2   �� $
��Wrap=�6<   Payment Due Date55  3   �� 56  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��57  1   $��20��6<   $
��Left=�58  ,   59  /   5;  +   5<  '   / 5>  "   �� 5?  &   .R�5@  *   �� ��64   �� *PaymentDueDateStr+5A  +   5B  '   5D       5E     -   5        PurchaseAmount��$	% 160 5E  O   $	+ 160Q�6[   $	, 160Q�6j   $$ Purchase Amount��6z   $- PurchaseAmountStr��6�   . 5F  "   �� 5G  &   .R�5H  *   �  5I  .   �� 5K  2   5L  3    5N  .   �� 5O  2   $
��auto �6C   �� 5P  2   $��10 �6D   .+�5R  .   ]� $��0��68   $��0��6E   .+�5S  2   �� $��Purchase Invoice Amount��6<   �� 5T  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5U  1   $��20��6<   $
��Left=�5V  ,   5W  /   5Y  +   5Z  '   / 5\  "   �� 5]  &   .R�5^  *   �� $
��Wrap=�64   $
��None{�6H   ��6_   �� *PurchaseAmountStr+5_  +   5`  '   5b       5c     -   5        	AmountDue��$	% 160 5c  H   $	+ 160Q�6T   $	, 160Q�6c   $$ 
Amount Due��6s   $- AmountDueStr��6�   . 5d  "   �� 5e  &   .R�5f  *   �  5g  .   �� 5h  2   6B    5k  .   �� 5l  2   $
��auto �6C   �� 5m  2   $��10 �6D   .+�5o  .   ]� $��0��68   $��0��6E   .+�5p  2   �� $
��Wrap=�6<   
Amount Due5r  3   �� 5s  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5t  1   $��20��6<   $
��Left=�5u  ,   5v  /   5x  +   5y  '   / 5{  "   �� 5|  &   .R�5}  *   �� $
��Wrap=�6R   $
��None{�6f   ��64   �� *AmountDueStr+5~  +   5  '   5�       5�     -   5        AmountAdjust��$	% 174 5�  �   $	+ 174Q�6�   $	, 174Q�6�   $- AmountAdjustedStr��6�   & 6G   �� *AmountAdjustedStr+$ TwoWay=�$ PropertyChanged=�$ 5�  "   � 5�  &   $	��172��6+    5�  *   �� 5�  .   6>    5�  *   �� 5�  .   $
��auto �6?   �� 5�  .   $��10 �6@   .+�5�  *   ]� -   5        2 ]�Name$2 AmountAdjusted��5�  Q   $��0��64   $��0��6A   .+�5�  .   �� $
��Wrap=�68   Amount Adjusted5�  /   �� 5�  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5�  1   $��20��6<   $
��Left=�5�  ,   5�  +   5�  '   3   EditingElementStyle3 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6W   -   5        5�  '   4   ElementStyle4 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   5�  '   5�     5�     5�     �� 5�     5 �� Orientation$5 
Horizontal=�6   $
��left=�67   $��0,1,0,0q�6R   .+�5�     � ��6   �� $ 
PurchaseNo��$ ActualWidth�.+�5�     ��   BorderStyleLeft#��[ 6!   ._�5�     �� $��Total��6)   $
��Bold"�66   6J   5�     5�     � 5�     ��6   �� $ PurchaseDate��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $�� ��6(   63   5�     5�     � 5�     ��6   �� $ PaymentDueDate��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $�� ��6(   63   5�     5�     � 5�     ��6   �� $ PurchaseAmount��$ ActualWidth�.+�5�     �� #��[ 6!   $��17��6J   $	��Top=�6V   ._�5�     ��   DisplayTotalStyle#��[ 6}   ��6(   �� *TotalPurchaseAmount+$ TwoWay=�$ PropertyChanged=�6�   5�     5�     � 5�     ��6   �� $ 	AmountDue��$ ActualWidth�.+�5�     ��   BorderStyleRight#��[ 6!   ._�5�     �� $�� ��6(   64   5�     5�     � 5�     ��6   �� $ AmountAdjusted��$ ActualWidth�.+�5�     �� #��[ 6!   $��17��6J   $	��Top=�6V   ._�5�     �� #��[ 6}   ��6(   �� *TotalAdjutedAmount+$ TwoWay=�$ PropertyChanged=�6�   5�     5�     5�     5�     ]� 5�     $��7��6   $��0��6%   $��2��65   $��Bottom=�6I   .+�5�     �� 
�������$��Italic$�6.   USTotal of Amount Adjusted column must be equal to Debit Note Amount. Amounts are in �� 5�  j   ��6t   �� *CurrencyName+6�   5�     5�     �� 5�     $��6��6   $��1��6%   $��Bottom=�66   $��4��6Q   $��10,0,0,0q�6e   
���  ����6�   �� $ 
DateErrors�6�   �� 5�     $��6��6   $��1��6%   $��4��65   $��10,0,0,0q�6I   
���  ����6l   �� *
PSErrors+$ TwoWay=�$ PropertyChanged=�6�   ]� 5�     $��7��6   $��2��6%   $��Right=�65   $��Bottom=�6Q   $��3��6l   $��	0 -10 3 0q�6�   .+�5�     �� -   5        6 ��Name$6 btnSave��5�     $
��Save��6Q   $��	10,10,0,0q�6`     ButtonStyle#���  6s   {�6*   �� *EnableSaveButton+��6�   �� *SaveCommand+6�   �� 5�     -   5        $6 btnClose��5�     $��Close��6+   $��	10,10,0,0q�6;   #���  6N   ��6t   �� *CloseCommand+6�   5�     5�     5�     5�     
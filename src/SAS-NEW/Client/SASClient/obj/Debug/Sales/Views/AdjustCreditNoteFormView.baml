   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SDN.Purchasing.ViewSDN.Purchasing.View  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5
      2    ,SDN.Purchasing.View.AdjustCreditNoteFormView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:SDN.Purchasing.View     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5
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
   $ Black��67   5      .��5      �� $��Hidden=�6   .��5   
   � $��
10,10,0,10q�6   $
��auto��6#   $
��auto��60     5         
ComboStyle��%#  '��       &	 �     �� 5!      " ��6   .�5"      ��  � ��$ 25��6/   6<   �� 5#       � ��$ 0,0,0,4q�6/   �� 5$       � ��
 �   �64   5%      �� 5&      " ��6+   .�5'      ��  � ��$ 0,0,0,4q�6/   �� 5(       � ��
 �   �64   5)      5*       � RowDefinitions 5+      �� 5,      6"   �� 5-      6"   �� 5.      6"   �� 5/      6"   �� 50      6"   �� 51      6"   �� 52      6"   �� 53      6"    � ColumnDefinitions 55      �� 56      $	��500 �6#   61   �� 57      $	��500 �6#   61   .+�5:      ]� $��0��6   $��0��6%   $��	0,0,120,0q�65   .+�5;      �� -   5        $��lblCustomerName��5;      $��Customer Name��64   6K   �� 5O      $��50,0,0,0q�6   {�.  $	��230��6>   $
��Left=�6�   ��6J   �� *SelectedCustomerName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5Q      ]� 5R      $��0��6   $��1��6%   $��	90,-2,0,0q�65   .+�5S      �� $��Adjust Credit Note No��6   $	��143��6:   $	��143��6I   $	��143��6X   6g   �� 5U      $��30,0,0,0q�6   	 �� 
IsReadOnly	 . $	��230��6>   $
��Left=�6�   ��6J   �� *AdjustCreditNoteNumber+$ TwoWay=�$ PropertyChanged=�6�   5V      �� 5i      -   5        $��lblBlank��5i   5   $��0��6   $��2��6%   $�� ��6G   $��3��6O   6c   ]� 5l      $��1��6   $��0��6%   $��	0,0,120,0q�65   .+�5m      �� $��Credit Note No��6   $	��143��63   $	��143��6B   $	��143��6Q   6`   �� 5w      $��0,4,0,0q�6   {�.  $	��230��6=   $
��Left=�6�   ��6I   �� *CreditNoteNo+$ TwoWay=�$ PropertyChanged=�6�   5y      �� 5z      -   5        $��lblJournalDate��5z   [   $��Adjust Credit Date��6   $��1��62   $��1��6?   $	��120��6O   $��90,0,0,0q�6r   5|      ]� 5}      $��	260 4 0 0q�6   $	��260��6-   $��1��69   $��1��6F   .+�5      (  "System.Windows.Controls.DatePicker  -   5        $��AdjustCreditDatePicker��5      $��26��6;   $	��230��6G   $	��230��6V   $
��Left=�6e   $��3,0,0,0q�6�   $	��Top=�5�   �   
   SelectedDate
 6   �� *AdjustCreditDateCalender+ �� BindingGroupName$ Group1��$ PropertyChanged=�  5�      :  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name 	 BaseBorderBrush `� 	Converter �� Path �� RelativeSource �� AncestorType��%�  '        7   �� 5�      "  6    .�5�      ��  � �� 5�   "   �� 5�   &   .R�5�   *   �� $ Date_TextBox��62   	 . $��0q�6[   $��Stretch=�6o   $��Stretch=�5�   .   $y�Hidden=�6Q   #��� 	 6e   .��6�   ��5�   .   `� 5�   2   8   .1�5�   6   �� $ SelectedDate�6>   �� 5�   6   $ 
DateFormat�6>   6R   �� 5�   6   $* $DataContext.AdjustCreditDateCalender�6>    5�   A   �� "  5�   3   .��5�   <   5�   +   5�   '   5�      5�      5�      5�      �� 5�      -   5        $ PART_TextBox��5�   o   $��-321 -1 0 0q�6   $��22��6/   #��[ 6;   $��0 0 0 0q�6�   $��Stretch=�6�   $��Stretch=�5�      $	��160��6�   ��65   �� $ AdjustCreditNoteDateStr�$ TwoWay=�$ PropertyChanged=�.��6�   5�      5�      ]� 5�      $��2��6   $��0��6%   $��	0,0,120,0q�65   .+�5�      �� -   5        $��lblDate��5�      $��Credit Note Date��6,   $	��143��6D   $	��143��6S   $	��143��6b   6q     5�      -   5        {�.  $	��230��5�   /   $	��230��6>   $
��Left=�6M   $��0,4,0,4q�6i   $	��230��5�   r   
 6   �� *Date+$ Group1��$ PropertyChanged=�  5�      ��%�  '        7   �� 5�      "  6    .�5�      ��  � �� 5�   "   �� 5�   &   .R�5�   *   �� $ Delivery_TextBox��62   	 . $��0q�6_   $��Stretch=�6s   $��Stretch=�5�   .   #��� 	 6R   .��6�   ��5�   .   `� 5�   2   8   .1�5�   6   �� $ SelectedDate�6>   �� 5�   6   $ 
DateFormat�6>   6R   �� 5�   6   $ DataContext.Date�6>    5�   A   �� "  5�   3   .��5�   <   5�   +   5�   '   5�      5�      5�      5�      5�      ]� 5�      $��3��6   $��0��6%   .+�5�      �� $	��143��6   Credit Note Amount �� 5�   (   65   5�      �� 5�      {�.  $	��230��6,   $
��Left=�6�   ��68   �� *	AmountStr+$ TwoWay=�$ PropertyChanged=�6�   5�      ]� 5�      $��4��6   $��0��6%   $��2��65   .+�5�      �� 
�������$��Italic$�6.   igTo adjust a Credit Note against 1 or more Sales Sales Invoices enters amounts in Amount Adjusted Column5�      5�      �� 5�      $��5��6   $��0��6&   $	��Top=�66   $	��140��6N   $��25��6Z   $��11,8,0,0q�6f   $
��Left=�5�       
 WaterMarkStyle#��[
 63   $��Search��6\   #��[ 6j   y�5�      `� 5�      # [ 6#   .1�5�      ��  �� ElementName$ cmbChequeNo��6"   $ Text.IsEmpty�6<   �� 5�      $ cmbChequeNo��6"   $ 	IsFocused�6<   5�      5�      �� 5�      -   5        $��cmbChequeNo��5�      $��5��5�      $��0��6%   $��6,5,0,0q�65   $	��160��5�   *   $��25��66   $
��Left=�6C    �� 
IsEditable . #��[ 5�      
������  �� DisplayMemberPath$ SalesNo��6�    �� SelectedValuePath$ SalesNo��6�   $	��Top=�6�   {�5�   F   �� *CustomerEnabled+$ TwoWay=�$ PropertyChanged=���6�   �� *PQDetailsEntityLst+ �� SelectedValue 5�   \   �� *SelectedSalesNo+.  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ SelectionChanged��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�      6	  0System.Windows.Interactivity.InvokeCommandAction	   	  Command 60   �� *SalesNoChangedCommand+5�      5�      �� 5�      $��5��6   $��0��6&   $��4��66   .+�5�      � .+�5�      &
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
   5        $	 dg1��5�   F   $��0��5�      
������ $	��990��6H   $��Visible=�6T   $ Disabled=�5�   >   $	 All=�5�      $��1q�62   ' 
  CanUserAddRows' .    HeaderStyle20#! [ 6k   ( 
  CanUserDeleteRows( .  ) 
  SelectionMode$) Single=�5�   L   $	��Top=�6c    .  $��0,33,2,0q�6�   * 
  
IsReadOnly* 5�   �   �� *EditDatagrid+��5�      �� *PQDetailsEntity+��6i   �� *PtSFGridHeight+# 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      -   5        SalesNo��$	% 160 5�   G   +   MaxWidth$	+ 160Q�6S   ,   MinWidth$	, 160Q�6b   $$ Sales No��6r   -   SortMemberPath$- SalesNo��6�   .   HeaderTemplate. 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   6B    5�   .   �� 5�   2   $
��auto �6C   �� 5�   2   $��10 �6D   .+�5�   .   ]� $��0��68   $��0��6E   .+�5�   2   �� $��Sales Invoice No.��6<   $��1��6U   $��0��6b   �� 5�   2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�   1   $��20��6<   $
��Left=�5�   ,   5�   /   5�   +   5   '   /   CellTemplate/ 5  "   �� 5  &   .R�5  *   �� �� 5  ,   0 �� Command0 66   �� *%#DataContext.NavigateToClientCommand+ �� " >�1 �� CommandParameter1 5  2   �� *	SalesNo+.�6W   .�5  2   �� $
��Wrap=�6U   $
��None{�6i   ��6<   �� *	SalesNo+6i   5  .   5	  *   5
  '   5       5     -   5        	SalesDate��$	% 160 5  J   $	+ 160Q�6V   $	, 160Q�6e   $$ 
Sales Date��6v   $- SalesDateStr��6�   . 5  "   �� 5  &   .R�5  *   �  5  .   �� 5  2   5  3    5  .   �� 5  2   $
��auto �6C   �� 5  2   $��10 �6D   .+�5  .   ]� $��0��68   $��0��6E   .+�5  2   �� $��Sales Invoice Date��6<   �� 5  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5  1   $��20��6<   $
��Left=�5  ,   5   /   5"  +   5#  '   / 5%  "   �� 5&  &   .R�5'  *   �� $��Right=�6R   ��64   �� *SalesDateStr+5(  +   5)  '   5+       5,     -   5        PaymentDueDate��$	% 160 5,  M   $	+ 160Q�6Y   $	, 160Q�6h   $$ Payment Due Date��6x   $- PaymentDueDateStr��6�   . 5-  "   �� 5.  &   .R�5/  *   �  50  .   �� 51  2   6B    54  .   �� 55  2   $
��auto �6C   �� 56  2   $��10 �6D   .+�58  .   ]� $��0��68   $��0��6E   .+�59  2   �� $
��Wrap=�6<   Payment Due Date5;  3   �� 5<  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5=  1   $��20��6<   $
��Left=�5>  ,   5?  /   5A  +   5B  '   / 5D  "   �� 5E  &   .R�5F  *   �� $��Right=�6W   ��64   �� *PaymentDueDateStr+5G  +   5H  '   5J       5K     -   5        SalesInvoiceAmount��$	% 160 5K  Q   $	+ 160Q�6]   $	, 160Q�6l   $$ Sales Amount��6|   $- SalesAmountStr��6�   . 5L  "   �� 5M  &   .R�5N  *   �  5O  .   �� 5Q  2   5R  3    5T  .   �� 5U  2   $
��auto �6C   �� 5V  2   $��10 �6D   .+�5X  .   ]� $��0��68   $��0��6E   .+�5Y  2   �� $��Sales Invoice Amount��6<   �� 5Z  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5[  1   $��20��6<   $
��Left=�5\  ,   5]  /   5_  +   5`  '   / 5b  "   �� 5c  &   .R�5d  *   �� $
��Wrap=�64   $
��None{�6H   $��Right=�6   ��6_   �� *SalesAmountStr+5e  +   5f  '   5h       5i     -   5        	AmountDue��$	% 160 5i  H   $	+ 160Q�6T   $	, 160Q�6c   $$ 
Amount Due��6s   $- AmountDueStr��6�   . 5j  "   �� 5k  &   .R�5l  *   �  5m  .   �� 5n  2   6B    5q  .   �� 5r  2   $
��auto �6C   �� 5s  2   $��10 �6D   .+�5u  .   ]� $��0��68   $��0��6E   .+�5v  2   �� $
��Wrap=�6<   
Amount Due5x  3   �� 5y  2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5z  1   $��20��6<   $
��Left=�5{  ,   5|  /   5~  +   5  '   / 5�  "   �� 5�  &   .R�5�  *   �� $
��Wrap=�6R   $��Right=�6f   $
��None{�6�   ��64   �� *AmountDueStr+5�  +   5�  '   5�       5�     -   5        AmountAdjusted��$	% 174 5�  �   $	+ 174Q�6�   $	, 174Q�6�   $- AmountAdjustedStr��6�   & 6L   �� *AmountAdjustedStr+$ TwoWay=�$ PropertyChanged=�$ 5�  "   � 5�  &    5�  *   �� 5�  .   6>    5�  *   �� 5�  .   $
��auto �6?   �� 5�  .   $��10 �6@   .+�5�  *   ]� $��0��64   $��0��6A   .+�5�  .   �� $
��Wrap=�68   Amount Adjusted5�  /   �� 5�  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5�  1   $��20��6<   $
��Left=�5�  ,   5�  +   5�  '   2   EditingElementStyle2 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6W   -   5        5�  '   3   ElementStyle3 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   5�  '   5�     5�     5�     �� 5�     4 �� Orientation$4 
Horizontal=�6   $
��left=�67   $��0,1,0,0q�6R   .+�5�     � ��6   �� $ SalesNo��$ ActualWidth�.+�5�     ��   BorderStyleLeft#��[ 6!   ._�5�     �� $��Total��6)   $
��Bold"�66   6J   5�     5�     � 5�     ��6   �� $ 	SalesDate��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $�� ��6(   63   5�     5�     � 5�     ��6   �� $ PaymentDueDate��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $�� ��6(   63   5�     5�     � 5�     ��6   �� $ SalesInvoiceAmount��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     ��   DisplayTotalStyle#��[ 6|   ��6(   �� *TotalInvoiceAmount+$ TwoWay=�$ PropertyChanged=�6�   5�     5�     � 5�     ��6   �� $ 	AmountDue��$ ActualWidth�.+�5�     ��   BorderStyleRight#��[ 6!   ._�5�     �� $�� ��6(   64   5�     5�     � 5�     ��6   �� $ AmountAdjusted��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� #��[ 6z   ��6(   �� *TotalAmountPaid+$ TwoWay=�$ PropertyChanged=�6�   5�     5�     5�     5�     ]� 5�     $��7��6   $��0��6%   $��2��65   $��Bottom=�6I   .+�5�     �� 
�������$��Italic$�6.   VTTotal of Amount Adjusted column must be equal to Credit Note Amount. Amounts are in �� 5�  k   ��6u   �� *CurrencyName+6�   5�     5�     �� 5�     $��6��6   $��1��6%   $��Bottom=�66   $��4��6Q   $��10,0,0,0q�6e   
���  ����6�   �� $ 
DateErrors�6�   �� 5�     $��6��6   $��1��6%   $��4��65   $��10,0,0,0q�6I   
���  ����6l   �� *
PSErrors+$ TwoWay=�$ PropertyChanged=�6�   ]� 5�     $��7��6   $��2��6%   $��Right=�65   $��Bottom=�6Q   $��3��6l   $��0 0 3 0q�6�   .+�5�     �� -   5        5 ��Name$5 btnSave��5�     $
��Save��6Q   $��	10,10,0,0q�6`     ButtonStyle#���  6s   {�6*   �� *EnableSaveButton+��6�   �� *SaveCommand+6�   �� 5�     -   5        $5 btnClose��5�     $��Close��6+   $��	10,10,0,0q�6;   #���  6N   ��6t   �� *CloseCommand+6�   5�     5�     5�     5�     
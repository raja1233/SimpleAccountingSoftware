   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SASClient.Customers.ViewsSASClient.Customers.Views  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      ;    5SASClient.Customers.Views.CustomersUnPaidInvoicesView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:SASClient.Customers.Views     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      $
��1024��5	        � 	Resources  5      ,  &SDN.Common.Converter.DateTimeConverter   DateTimeFormatter9  3SDN.Common.Converter.TextInputToVisibilityConverter " TextInputToVisibilityConverter5  /SDN.Common.Converter.MultipleParameterConverter  MultiParamterConverter  brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder��%�   &	        &	      &	 &     &	 9     &	 X     &	 v       5   
   6@     5   
   61     5   
   6N   �� 5   
   $ White��6;   �� 5   
   $
 Gray��6;   �� 5   
   $ Black��67   5      .��5      �� $��Stretch=�6   $
��Auto=�62   $
��Auto=�6U   .��5   
   � $��0,0,0,0q�6    � RowDefinitions 5      �� 5      $��30 �6    �� 5      $��0 �6    �� 5      $��25 �6    �� 5      $	��10* �6    �� 5      $��30 �6    6.    � ColumnDefinitions 5      �� 5       $	��300 �6#   63   �� 5!      $	��724 �6#   61   .+�5#      ]� $��0��6   $��0��6%   $��2��65   $��10,0,0,0q�6I   .+�5$      �� $��Statement Date��6   $��Center=�63   6P   (  "System.Windows.Controls.DatePicker  5>      -   5        $
��Left=�5>   G   $	��150��6c   $	��150��6r   $��20,0,0,0q�6�   $��2��5@      {�5>      �� *EnableStartDropDown+   SelectedDate 5@   -   �� *SelectedStatementDate+  5B      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value ��Name	 �� 
IsReadOnly  BaseBorderBrush
 `� 	Converter �� Path �� RelativeSource �� AncestorType��%�  '        7   �� 5C      "  6    .�5D      ��  � �� 5E   "   �� 5F   &   .R�5G   *   �� $ PART_TextBox��62   	 . $��0q�6Z   $��Stretch=�6n   $��Stretch=�6�   #���  6�   .��6�   ��5H   .   `� 5I   2   8
   .1�5J   6   �� $ SelectedDate�6>   �� 5K   6   $ 
DateFormat�6>   6R   �� 5L   6   $' !DataContext.SelectedStatementDate�6>    5M   A   �� "  5O   3   .��5P   <   5Q   +   5R   '   5T      5U      5V      5W      5X      �� 5Y      $��2��6   $��0��6%   $��2��65   $��10,0,0,0q�6I   $��Italic$�5Z      
�������_]Select Customers to print statement. Click on a Customer Name to see Unpaid Invoices details.5\      �� 5^      $��0��6   $��3��6(   $��2��65   $��35 2 0 0q�6I     WaterMarkStyle#��[ 6]   $
��Left=�5_      $��Search��62   #��[ 6@   y�5`      `� 5a      #
 [ 6#   .1�5b      ��  �� ElementName$ cmbQuotNoSearch��6"   $ Text.IsEmpty�6@   �� 5c      $ cmbQuotNoSearch��6"   $ 	IsFocused�6@   5d      5f      �� 5g      -   5        $��cmbQuotNoSearch��5j   W   
������ #��[ 5g   0   $��0��6d   $��3��6t    �� 
IsEditable . $��2��5h      $
��Left=�6*   $��10 0 0 0q�6E   $��25��6W   $	��Top=�6f   $	��269��6~   $	��290��6�    �� DisplayMemberPath$ CustomerName��5j       �� SelectedValuePath$ 
CustomerID��68   ��5i      �� *LstCustomers+ �� SelectedValue 5k      �� *SelectedCustomerID+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5l      &   System.Windows.Controls.DataGrid  5n      -   5          Name$ CustomGridLines1��5n      $��0��6Y   $��3��6i      GridLinesVisibility$	 All=�5o   P      HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   AutoGenerateColumns .  $	��Top=�5q      $   HorizontalScrollBarVisibility$ Hidden=�63   "   VerticalScrollBarVisibility$ Disabled=�6Z     BackHeaderStyle20   ColumnHeaderStyle# [ 5r         HeadersVisibility$	 All=�6R   $��	10,30,0,0q�6j   ��5n   1   �� *BackGroundLines+��5o      �� $	 dg1��$ ActualHeight���6l   �� $	 dg1��$ ActualWidth�   Columns 5s      0  *System.Windows.Controls.DataGridTextColumn  5t      ,  &System.Windows.Controls.DataGridColumn   Header$  ��6)       Width5	  /System.Windows.Controls.DataGridLengthConverter$  20	 6L   1
  +System.Windows.Controls.DataGridBoundColumn! 
  Binding! 63   �� *Col0+6Y     5u      $  ��6)   $	  255	 6M   ! 63   �� *Col1+6[   5y        5z      -   5        $	 dg1��5z   g   $	 All=�6   $��0��61   $��3��6A   
������ "   
IsReadOnly" . $��1q�6�   $	��290��6�   $	��290��6�   $��	10,30,0,0q�5{      #   CanUserAddRows# .  $   CanUserDeleteRows$ .  $	��Top=�5|       	 HeaderStyle20# [	 6�   $ 
CustomerID��5}      %   CanUserSortColumns% . &   CanUserResizeColumns& .  '   CanUserResizeRows' .   .  
���   ���5{   )   �� *
GridHeight+��6H   �� $ LstCustomers� 5|   1   �� *SelectedCustomerID+$ TwoWay=�$ PropertyChanged=� 5      4  .System.Windows.Controls.DataGridTemplateColumn  5�      $  20	 6.    5�      �� 5�      -   5        5�   c   (   CellTemplate( 5�      �� 5�      .R�5�   "   �� ) d� 	IsChecked) 6,   �� $ 
IsSelected�$ TwoWay=�$ PropertyChanged=�5�   #   5�      5�        5�      $	  255	 6-   *   MaxWidth$	* 255Q�69   $ Customer Name��6H   +   CanUserSort+ . ,   SortMemberPath$, CustomerName��6r   -   HeaderTemplate- 5�      �� 5�      .R�5�   "   �  5�   &   �� 5�   *   6:    5�   &   �� 5�   *   ��6;   �� $ CustomerName��$ ActualWidth�.+�5�   &   ]� $��0��60   $��0��6=   .+�5�   *   �� #��z��64   5�   +   �� 5�   *   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��60   $��10��5�   1   $��20��6<   $
��Left=�5�   ,   5�   '   �� 5�   &   $��1��6-   $��0��6:    
 
HeaderLine#��[
 6J   ._�5�   *   �� $�� ��64   $��1��6=   $��0��6J   5�   '   5�   #   5�      ( 5�      �� 5�      .R�5�   "   �� ��6,   �� $ CustomerName�6Q   5�      5�        5�      )  #System.Windows.Controls.DataGridRow. �� 	Resources��%�   '        �� 5�      "  6   . 5�      ���� 5�      $
 Gray��6q   (��       6.   *1/SystemColors.InactiveSelectionHighlightBrushKey+)6q   5�      5�      5�      .  (System.Windows.Interactivity.Interaction/   Triggers/ 5�      /  )System.Windows.Interactivity.EventTrigger  5�      0   	EventName$0 SelectionChanged��6%   .  (System.Windows.Interactivity.TriggerBase1   Actions.1 5�      6  0System.Windows.Interactivity.InvokeCommandAction  2   Command2 60   �� *SelectChangedCommand+5�      3   	CellStyle3 5�      �� 5�      *  $System.Windows.Controls.DataGridCell"  6   4 �� Triggers4 5�      P� 5�      5 P� Property5 �@ 
IsSelected6 P� Value6 . . �5�   "   ��  � ��
 �   �5�   2   �� 5�   "    � ��
 �   �5�   5   �� 5�   "    � ��
 �����5�   2   5�      5�      7   RowStyle7 5�      �� 5�      "  6   4 5�      P� 5�      5 �@ 
IsSelected6 . . �5�   "   ��  � ��
 �   �5�   2   �� 5�   "    � ��
 �   �5�   5   �� 5�   "    � ��
 �����5�   2   5�      5�      5�      �� 5�      $��1��6   $��3��6)   .+�5�      � .+�5�        -   5        $ CustomGridLines2��5�      $
��Left=�5�      $	 All=�6j   $	��Top=�5�      
 �����
 ����� .  $ Hidden=�5�      $ Disabled=�6C   # [ 5�      $	 All=�6R   $��10,1,0,0q�6j   ��5�   9   �� *BackGroundLines+��5�   5   �� $	 dg2��$ ActualHeight���6�   �� $	 dg2��$ ActualWidth� 5�        5�      $  ��61   $	  135	 6T   ! 6;   �� *Col0+6b     5�      $  ��61   $	  135	 6U   ! 6;   �� *Col1+6c     5�      $  ��61   $	  140	 6U   ! 6;   �� *Col2+6c     5�      $  ��61   $	  140	 6U   ! 6;   �� *Col3+6c     5�      $  ��61   $	  150	 6U   ! 6;   �� *Col4+6c   5�        5�      -   5        $	 dg2��5�   S   $	 All=�6   
������ " . $��1q�6s   $	��702��6�   $	��702��6�   $��10,0,0,0q�5�      $
��Left=�6%   $��47��6B   # .  $ .  $	��Top=�5�      # [	 62   % .  & .  ' .   .  
���   ���5�   O   �� $ LstBalances� 5�        5�      $	  135	 61   $	* 135Q�6=   $ Balance��6L   ! 6]   �� $ 
BalanceStr�5�        5�      $	  135	 61   $	* 135Q�6=   $ 	1-30 Days��6L   ! 6_   �� $ Oneto30DaysStr�5        5     $	  140	 61   $	* 140Q�6=   $ 
31-60 Days��6L   ! 6`   �� $ Thirtyoneto60DaysStr�5       5     $	  140	 61   $	* 140Q�6=   $ 
61-90 Days��6L   ! 6`   �� $ Sixtyoneto90DaysStr�5       5     $	  150	 61   $	* 150Q�6=   $ 	> 90 Days��6L   ! 6_   �� $ GreaterThen90DaysStr�5     5       5
     -   5        $ CustomGridLines3��5
     $
��Left=�5     $	 All=�6j   $	��Top=�5     
 �����
 ����� .  $ Hidden=�5     $ Disabled=�6C   # [ 5     $	 All=�6R   $��	10,57,0,0q�6k   ��5
  9   �� *BackGroundLines+��5  5   �� $	 dg3��$ ActualHeight���6�   �� $	 dg3��$ ActualWidth� 5       5     $  ��61   $	  115	 6T   ! 6;   �� *Col0+6b     5     $  ��61   $	  115	 6U   ! 6;   �� *Col1+6c     5     $  ��61   $	  115	 6U   ! 6;   �� *Col2+6c     5     $  ��61   $	  115	 6U   ! 6;   �� *Col3+6c     5     $  ��61   $	  115	 6U   ! 6;   �� *Col4+6c     5     $  ��61   $	  110	 6U   ! 6;   �� *Col5+6c   5       5     -	   5        $	 dg3��5  T   $	 All=�6   
������ " . $��1q�6t   $	��702��6�   $	��702��6�   $��	10,60,0,0q�5     $
��Left=�6&   # .  $ .  $	��Top=�5     # [	 61   % . & .  ' .   .  
���   ���5  C   �� *InvoiceGridHeight+��6i   �� $ LstInvoiceDetails� 5       5      -
   5        	InvNo��8   MinWidth$	8 115Q�5   D   $	* 115Q�6S   $ Invoice No.��6b   $
  Auto	 6w   $, 	InvoiceNo��6�   + .  - 5!  "   �� 5"  &   .R�5#  *   �  5$  .   �� 5%  2   $
��auto �6C   �� 5&  2   $��10 �6D   .+�5(  .   �� #��z��68   5)  +   5*  '   ( 5,  "   �� 5-  &   .R�5.  *   �� �� 5/  ,     HyperlinkDataGrid#��[ 66   9 �� Command9 6a   �� *&$DataContext.NavigateToInvoiceCommand+ �� " >�: �� CommandParameter: 50  2   �� *	InvoiceNo+.�6Y   .�51  2   �� ��6<   �� *	InvoiceNo+52  .   53  *   54  '   56       58     -   5        InvDate��$	  115	 58  B   $	* 115Q�6N   $ Invoice Date��6]     HeaderStyle20Right;   HeaderStyle#; [ 59  1   $, InvoiceDate��6c   + .  ! 58  s   �� $ InvoiceDateStr�< 
  ElementStyle< 5:  "   �� 5;  &   " ��6,   .�5<  *   ��  � ��$ Right=�6P   6`   5=  '   - 5?  "   �� 5@  &   .R�5A  *   �  5B  .   �� 5C  2   $
��auto �6C   �� 5D  2   $��10 �6D   .+�5F  .   �� #��z��68   5L  +   5M  '   5O       5P     -   5        
InvAmt��$	  115	 5P  A   $	* 115Q�6M   $ Invoice Amount��6\   #; [ 5Q  1   $, InvoiceAmount��6c   + .  ! 5P  t   �� $ InvoiceAmountStr�< 5R  "   �� 5S  &   " ��6,   .�5T  *   ��  � ��$ Right=�6P   6`   5U  '   - 5W  "   �� 5X  &   .R�5Y  *   �  5Z  .   �� 5[  2   $
��auto �6C   �� 5\  2   $��10 �6D   .+�5^  .   �� #��z��68   5d  +   5e  '   5g       5h     -   5        DueDate��$	  115	 5h  B   $	* 115Q�6N   $ Payment Due Date��6]   #; [ 5i  1   $, PaymentDueDate��6c   + .  ! 5h  w   �� $ PaymentDueDateStr�< 5j  "   �� 5k  &   " ��6,   .�5l  *   ��  � ��$ Right=�6P   6`   5m  '   - 5o  "   �� 5p  &   .R�5q  *   �  5r  .   �� 5s  2   $
��auto �6C   �� 5t  2   $��10 �6D   .+�5v  .   �� #��z��68   5|  +   5}  '   5       5�     -   5        Amtpaid��$	  115	 5�  B   $	* 115Q�6N   $ Amount Paid��6]   $, 
AmountPaid��5�  X   + .  #; [ 6�   ! 61   �� $ AmountPaidStr�< 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   6`   5�  '   - 5�  "   �� 5�  &   .R�5�  *   �  5�  .   �� 5�  2   $
��auto �6C   �� 5�  2   $��10 �6D   .+�5�  .   �� #��z��68   5�  +   5�  '   5�       5�     -   5        
AmtDue��$	  110	 5�  A   $	* 110Q�6M   $ 
Amount Due��6\   $, 	AmountDue��5�  (   + .  #; [ 6�   ! 6E   �� $ AmountDueStr�< 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ Right=�6P   6`   5�  '   - 5�  "   �� 5�  &   .R�5�  *   �  5�  .   �� 5�  2   $
��auto �6C   �� 5�  2   $��10 �6D   .+�5�  .   �� #��z��68   5�  +   5�  '   5�     5�     5�     �� 5�     = �� Orientation$= 
Horizontal=�6R   $
��left=�6k   $��11,1,0,1q�6�   ��6   �� $	 dg3��$ ActualWidth�.+�5�     � ��6   �� $ InvNo��$ ActualWidth�.+�5�     ��   BorderStyleLeft#��[ 6!   ._�5�     �� $��Total��6)   $
��Bold"�66   6J   5�     5�     � 5�     ��6   �� $ InvDate��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $�� ��6(   63   5�     5�     � 5�     ��6   �� $ InvAmt��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     ��   DisplayTotalStyle#��[ 6|   ��6(   �� *TotalInvoiceAmount+$ TwoWay=�$ PropertyChanged=�6�   5�     5�     � 5�     ��6   �� $ DueDate��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� 6+   5�     5�     � 5�     ��6   �� $ Amtpaid��$ ActualWidth�.+�5�     ��   BorderStyleRight#��[ 6!   ._�5�     �� #��[ 6y   ��6(   �� *TotalPaidAmount+$ TwoWay=�$ PropertyChanged=�6�   5�     5�     � 5�     ��6   �� $ AmtDue��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� #��[ 6x   ��6(   �� *TotalDueAmount+$ TwoWay=�$ PropertyChanged=�6�   5�     5�     5�     5�     �� 5�     $��5��6   $��0��6&   $��2��66   $= 
Horizontal=�6J   $��Bottom=�6c   $��6,0,0,0q�6~   .+�5�     �� $��Amounts include ��6   $��Italic$�65   
�������6\   �� 5�     $��Italic$�65   
���������6   �� *	TaxName+6\   �� 5�     $��20,0,0,0q�6   $��  Amounts are in  ��6.   $��Italic$�6H   
�������6o   �� 5�     $��Italic$�6:   
���������6   �� *CurrencyName+6a   5�     �� 5�     $= 
Horizontal=�6   $��1��62   $��5��6B   $��Right=�6O   $��Bottom=�6k   $��0,5,10,0q�6�   .+�5�     �� $��Print��6     ButtonStyle#���  6�   ��6)   �� *clickCommand+$ OneWay=���6W   �� $ SelectedStatementDate�6�   �� 5�     $��Close��6   $��10,0,0,0q�6)   #���  5�     ��5�  ;   �� $ CloseCommand�5�     5�     5�     5�     5�     
   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      D @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SASClient.CashBank.ViewsSASClient.CashBank.Views 5      0   *SASClient.CashBank.Views.TransferMoneyView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      8local&clr-namespace:SASClient.CashBank.Views     5      $
��1024��5	        � 	Resources  5      ,  &SDN.Common.Converter.DateTimeConverter   DateTimeFormatter.  (SDN.Common.Converter.RowToIndexConverter  RowToIndexConverter9  3SDN.Common.Converter.TextInputToVisibilityConverter " TextInputToVisibilityConverter  BorderStyle �� 
TargetType �� Property �� Value  TextBoxStyle  brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder��%�  &	        &	      &	 &     &	 9     &	 �     &	 �     &	     &	 *      5   
   6@     5   
   6&     5   
   61   �� 5   
   " ��6$   .�5      ��  � ��$ 1q�60   �� 5       � ��
 �   �6,   5      �� 5   
   " ��6%   .�5      ��  � ��$ 0q�60   5      �� 5   
   $ White��6;   �� 5   
   $
 Gray��6;   �� 5   
   $ Black��67   5      .��5      �� $
��Auto=�6   $
��Auto=�66   .��5   
   � $��
10,10,0,10q�6   $
��auto��6#   $
��auto��60     5        
ComboStyle��%#  '��       &	 �     �� 5       " ��6   .�5!      ��  � ��$ 25��6/   6<   �� 5"       � ��$ 0,0,0,4q�6/   �� 5#       � ��
 �   �64   5$      �� 5%      " ��6+   .�5&      ��  � ��$ 0,0,0,4q�6/   �� 5'       � ��
 �   �64   5(      5)       � RowDefinitions 5*      �� 5+      $��30 �6    6.   �� 5,      $��30 �6    6.   �� 5-      $��33 �6    6.   �� 5.      $��33 �6    6.   �� 5/      $��33 �6    6.   �� 50      $��33 �6    6.   �� 51      $	��10* �6    6/    � ColumnDefinitions 53      �� 54      $	��300 �6#   61   �� 55      $	��213 �6#   61   �� 56      $��93 �6#   60   �� 57      $	��150 �6#   61   �� 58      $	��100 �6#   61   �� 59      $	��150 �6#   61   .+�5=      ]� $��0��6   $��0��6%   .+�5>      �� $��Cash/Cheque No.��6   $	��140��63   6A   5D      ]� 5E      $��0��6   $��1��6%   .+�5F      �� $��*��6   
���  ��$��1,0,1,0q�66   �� 5G      $	��200��6   $��0,0,0,5q�6&   $
��Left=�67    �� 
IsReadOnly 6R   �� *IsTextBoxReadOnly+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=���5H      �� *CashChequeNo+$ TwoWay=�$	 PropertyChanged=�6j   5I      ]� 5J      $��0��6   $��3��6%   $��4��65   $��	-80 0 0 0q�6I   .+�5K      �� 
�������$��Italic$�6.   =;For Cheque, Credit Card, etc., enter TM- followed by number6~   5L      ]� 5M      $��1��6   $��0��6%   .+�5N      �� -   5        $��lblDate��5N      $
��Date��6,   $	��140��68   $	��140��6G   $	��140��6V   6e   5P      ]� 5R      $��1��6   $��1��6%   .+�5S      �� $��*��6   
���  ��$��0,0,1,0q�66   (  "System.Windows.Controls.DatePicker  5T      -   5        $��TransferDatepicker��5T      $	��200��67   $	��200��6F   $
��Left=�6U   $��1,2,0,3q�6q   $	��200��5U   �   
   SelectedDate
 6   �� *TransferDateCalender+ �� BindingGroupName$ Group1��$	 PropertyChanged=�  5V      :  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name 	 BaseBorderBrush `� 	Converter �� Path �� RelativeSource �� AncestorType��%�  '        7   �� 5W      "  6    .�5X      ��  � �� 5Y   "   �� 5Z   &   .R�5[   *   �� $ Delivery_TextBox��62    . $��0q�6_   $��Stretch=�6s   $��Stretch=�5\   .   #��� 	 6R   .��6�   ��5]   .   `� 5^   2   8   .1�5_   6   �� $ SelectedDate�6>   �� 5`   6   $ 
DateFormat�6>   6R   �� 5a   6   $&  DataContext.TransferDateCalender�6>    5b   A   �� "  5c   3   .��5d   <   5e   +   5f   '   5h      5i      5j      5k      �� 5l      -   5        $ PART_TextBox��5l   o   $��-243 -2 0 0q�6   $��21��6/   #��[ 6;    .  $��0 0 0 0q�6�   $��Stretch=�6�   $��Stretch=�5m      $	��160��6�   ��65   �� $ CashChequeDateStr�$ TwoWay=�$	 PropertyChanged=�.��6�   5o      5p      ]� 5q      $��4��6   $��0��6%   .+�5r      �� $
��auto��6   /-Transfered from Cash/Bank/Credit Card Account5t      5u      ]� 5w      $��5��6   $��0��6%   .+�5x      �� $
��auto��6   -+Transfered to Cash/Bank/Credit Card Account5z      5{      ]� 5|      $��4��6   $��1��6%   .+�5}      �� $��*��6   
���  ��$��1,0,2,0q�66   �� 5~      -   5        $��cmbTransferFromAcName��5~      $��0,2,0,5q�69   $	��200��5      $��25��6(   $
��Left=�65   
���   � �� DisplayMemberPath$ AccountName��5�   d    �� SelectedValuePath$ 	AccountID��6�   $	��Top=�6�   ��5~   L   �� *$"TransferFromCashAndBankAccountsLst+{�5   P   �� *IsCashChequeEnabled+$ TwoWay=�$	 PropertyChanged=� �� SelectedValue 5�   #   �� *'%SelectedtransferFromCashAndBankAcntID+.   (System.Windows.Interactivity.Interaction   Triggers 5�      /   )System.Windows.Interactivity.EventTrigger  5�         	EventName$ SelectionChanged��6)   .   (System.Windows.Interactivity.TriggerBase   Actions. 5�      6	   0System.Windows.Interactivity.InvokeCommandAction	   	  Command 64   �� * AccountSelectionChangedCommand+5�      5�      5�      ]� 5�      $��5��6   $��1��6%   .+�5�      �� $��*��6   
���  ��$��1,0,2,0q�66   �� 5�      -   5        $��cmbTransferToAcName��5�      $��0,2,0,5q�67   $	��200��5�      $��25��6(   $
��Left=�65   
���   �$ AccountName��5�   _   $ 	AccountID��6   $	��Top=�6�   ��5�   J   �� *$"TransferFromCashAndBankAccountsLst+{�5�   P   �� *IsCashChequeEnabled+$ TwoWay=�$	 PropertyChanged=� 5�   #   �� *" SelectedtransferToCashBankAcntID+ 5�        5�      $ SelectionChanged��6)   . 5�      	   64   �� **(TransferToAccountSelectionChangedCommand+5�      5�      5�      ]� 5�      $��2��6   $��0��6%   .+�5�      �� $��Amount��6   �� 5�      $��5,0,0,0q�6:   ��6   �� *CurrencyName+6M   5�      ]� 5�      $��2��6   $��1��6%   .+�5�      �� $��*��6   
���  ��$��1,0,2,0q�66   �� 5�      -   5        $��0,0,0,5q�5�       �� 	MaxLength$ 18��6+   $	��200��6:   $
��Left=�6�   ��6q   �� *	AmountStr+$ TwoWay=�$	 PropertyChanged=�.��6�    5�        5�      $ TextChanged��6)   . 5�      	   64   �� *TextChangedCommand+5�      .��5�   .   5�      5�      ]� 5�      $��3��6   $��0��6%   .+�5�      �� $	��140��6   	Remarks5�      5�      ]� 5�      $��3��6   $��1��6%   .+�5�      �� $	 200��6   $��8,0,0,5q�6*   $	��200��6;   $
��Left=�6�   ��6G   �� *	Remarks+$ TwoWay=�$	 PropertyChanged=�6�   5�      �� 5�      -   5        $"��lblTransferFromBeforeBalance��5�      $��4��6<   $��2��6I   $��Before Balance��6Y   $��Center=�6o   $��5,0,3,0q�6�   $��86��6�   6�   �� 5�      -   5        $ ��lblTransferToBeforeBalance��5�      $��5��6:   $��2��6G   $��Before Balance��6W   $��Center=�6m   $��5,0,3,0q�6�   $��86��6�   6�   �� 5�      -	   5        $!��lblTransferFromAfterBalance��5�      $��4��6;   $��4��6H   $��After Balance��6X   $��Center=�6m   $��	12,0,13,0q�6�   $��76��6�   6�   �� 5�      -
   5        $��lblTransferToAfterBalance��5�      $��5��69   $��4��6F   $��After Balance��6V   $��Center=�6k   $��	12,0,13,0q�6�   $��76��6�   6�   �� 5�      -   5        $"��txtTransferFromBeforeBalance��5�      $��4��6:   $��3��6G   $��1,2,0,7q�5�       . $
��Auto��6e   ��6%   �� *TransferFromBeforeBalanceStr+6e   �� 5�      -   5        $ ��txtTransferToBeforeBalance��5�      $��5��68   $��3��6E   $��1,1,0,6q�5�       . $
��Auto��6e   ��6'   �� *TransferToBeforeBalanceStr+6e   �� 5�      -   5        $!��txtTransferFromAfterBalance��5�      $��4��69   $��5��6F   $��1,2,0,7q�5�       . $
��Auto��6f   ��6'   �� *TransferFromAfterBalanceStr+6f   �� 5�      -   5        $��txtTransferToAfterBalance��5�      $��5��67   $��5��6D   $��1,1,0,6q�5�       . $
��Auto��6d   ��6'   �� *TransferToAfterBalanceStr+6d   �� 5�      $��12��6   $��4��6&   $��Bottom=�66   $��4��6Q   $��
-200,0,0,0q�6e   
���  ����6�   �� $ PSErrors�6�   �� 5�      $��12��6   $��4��6&   $��Bottom=�66   $��4��6Q   $��
-200,0,0,0q�6e   
���  ����6�   �� $ 
DateErrors�6�   ]� 5�      $��6��6   $��4��6%   $��Right=�65   $��Bottom=�6Q   $��2��6l   $��0 0 0 0q�6�   $��35��6�   $	��210��6�   .+�5�      �� -   5         ��Name$ btnNew��5�      $	��New��6)   $��	10,10,0,0q�67    
 ButtonStyle#��� 
 6J   $	��New��6�   ��6p   �� *NewPSCommand+6�   �� 5�      -   5        $ btnSave��5�      $
��Save��6*   $��	10,10,0,0q�69   #��� 
 6L   ��6r   �� *SaveCommand+6�   �� 5�      -   5        $ btnClose��5�      $��Close��6+   $��	10,10,0,0q�6;   #��� 
 6N   ��6t   �� $ CloseCommand�6�   5�      5�      5�      5�      
   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SASClient.CashBank.ViewsSASClient.CashBank.Views  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      +    %SASClient.CashBank.Views.PayMoneyView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:SASClient.CashBank.Views     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      $
��1024��5	        � 	Resources  5      ,  &SDN.Common.Converter.DateTimeConverter   DateTimeFormatter.  (SDN.Common.Converter.RowToIndexConverter  RowToIndexConverter9  3SDN.Common.Converter.TextInputToVisibilityConverter " TextInputToVisibilityConverter  BorderStyle �� 
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
 �   �64   5(      5)       � RowDefinitions 5*      �� 5+      $��30 �6    6.   �� 5,      $��30 �6    6.   �� 5-      $��33 �6    6.   �� 5.      $��30 �6    6.   �� 5/      $��30 �6    6.   �� 50      $��30 �6    6.   �� 51      $��33 �6    6.   �� 52      $��30 �6    6.   �� 53      $��30 �6    6.   �� 54      $��30 �6    6.   �� 55      $��30 �6    6.   �� 56      $��30 �6    6.   �� 57      $	��10* �6    6/    � ColumnDefinitions 59      �� 5:      $	��341 �6#   61   �� 5;      $	��341 �6#   61   �� 5<      $	��330 �6#   61   .+�5?      ]� $��0��6   $��0��6%   .+�5@      �� -   5        $��lblAccountName��5@      $��Account Name��63   $	��140��6G   6U   5B      ]� 5C      $��0��6   $��1��6%   .+�5D      �� $��*��6   
���  ��$��0,0,0,0q�66   �� 5E      -   5        $��cmbAccountName��5E      $��2,2,0,0q�62   $	��230��5F      $��25��6(   $
��Left=�65   #��[ 5G       �� SelectedValuePath$ 	AccountID��6t   $	��Top=�6�   ��5E   D   �� *LinkedAccountsLst+{�5F   P   �� *IsCashChequeEnabled+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� SelectedValue
 5G   D   �� *SelectedLinkedAcntID+��5H      �� 5I      .R�5J      ��  ��Name$ AccountName��6(   ��6=   �� *AccountName+6\    �� Triggers 5K      �� 5L   "    �� Value$
 True��5N       �� Binding 5M      ��  �� Path$ DataContext.IsLinked� �� RelativeSource �� *TemplatedParent+.a�5O   &   ��  �� 
TargetName$ AccountName��6C    � ��
 �����5P   '   5Q   #   5S      ��5U      �� 5V      " ��6    .�5W      ��  � �� 5X   "   �� 5Y   &   .R�5Z   *   �  �Name$ gd��6/   
���   � 5[   .   �� 5\   2   �� 5]   2   .+�5_   .   �� $��5q�68   $��0��6C   ��6S   �� *AccountName+�� 5`   .   $��5q�68   $��1��6C   ��6S   �� *AccountTypeName+5a   +    �� Triggers 5b   *   P� 5c   .    P� Property �@��
IsSelected P� Value . . �5d   2   �� $ gd��69    � ��
 �����6o   �� 5e   2   $ gd��69    � ��
 �����6|   5f   /   P� 5g   .    �@J�IsMouseOver . . �5h   2   �� $ gd��69    � ��
 ��  �6o   �� 5i   2   $ gd��69    � ��
 �����6|   5j   /   5s   '   5u      5v      5x      5z      ]� 5{      $��0��6   $��1��6%   $��2,2,0,0q�66   .+�5|      �� $��17 5 0 0q�6    	 WaterMarkStyle#��[	 62   $
��Left=�5}      $��Search��62   #��[ 6@   y�5~      `� 5       `� 	Converter# [ 6'   .1�5�      ��  �� ElementName$ cmbAccountName��6&   $ Text.IsEmpty�6C   �� 5�      $ cmbAccountName��6&   $ 	IsFocused�6C   5�      5�      5�      �� 5�      $��0��6   $��1��6(   67   ]� 5�      $��2��6   $��0��6%   .+�5�      �� $��Cash/Bank A/c Name��6   $	��140��67   $	��140��6F   $	��140��6U   6d   5�      ]� 5�      $��2��6   $��1��6%   .+�5�      �� -   5        $��	cmbAcName��5�      $��7,2,0,5q�6-   $	��230��5�      $��25��6(   $
��Left=�65   
���   � �� DisplayMemberPath$ AccountName��5�   U   $ 	AccountID��6u   $	��Top=�6�   ��5�   @   �� *CashAndBankAccountsLst+{�5�   P   �� *IsCashChequeEnabled+$ TwoWay=�$	 PropertyChanged=�
 5�   #   �� *SelectedCashBankAcntID+.  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ SelectionChanged��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� * AccountSelectionChangedCommand+5�      5�      5�      ]� 5�      $��3��6   $��0��6%   .+�5�      �� $��Cash/Cheque No.��6   $	��140��63   6A   5�      ]� 5�      $��3��6   $��1��6%   .+�5�      �� $��*��6   
���  ��$��1,0,1,0q�66   �� 5�      $	��230��6   $��0,0,0,3q�6&   $
��Left=�67    �� 
IsReadOnly 6R   �� *IsTextBoxReadOnly+$ TwoWay=�$	 PropertyChanged=���5�      �� *CashChequeNo+$ TwoWay=�$	 PropertyChanged=�6j   5�      ]� 5�      $��3��6   $��2��6%   $��	-90 0 0 0q�65   .+�5�      �� 
�������$��Italic$�6.   =;For Cheque, Credit Card, etc., enter PM- followed by number6~   5�      ]� 5�      $��4��6   $��0��6%   .+�5�      �� -   5        $��lblDate��5�      $
��Date��6,   $	��140��68   $	��140��6G   $	��140��6V   6e   5�      ]� 5�      $��4��6   $��1��6%   .+�5�      �� $��*��6   
���  ��$��0,0,1,0q�66   (  "System.Windows.Controls.DatePicker  5�      -   5        $��PayDatepicker��5�      $	��230��5�      $	��230��6,   $
��Left=�6;   $��1,2,0,3q�6W   $	��230��5�   �      SelectedDate 6*   �� *PayDateCalender+ �� BindingGroupName$ Group1��$	 PropertyChanged=�  5�      :	  4System.Windows.Controls.Primitives.DatePickerTextBox  ��Name 
 BaseBorderBrush! �� AncestorType��%�  '	        7   �� 5�      " 	 6    .�5�      ��  � �� 5�   "   �� 5�   &   .R�5�   *   �� $  Delivery_TextBox��62    . $��0q�6_   $��Stretch=�6s   $��Stretch=�5�   .   #��� 
 6R   .��6�   ��5�   .   `� 5�   2   8   .1�5�   6   �� $ SelectedDate�6>   �� 5�   6   $ 
DateFormat�6>   6R   �� 5�   6   $! DataContext.PayDateCalender�6>    5�   A   �� "!  5�   3   .��5�   <   5�   +   5�   '   5�      5�      5�      5�      �� 5�      -   5        $  PART_TextBox��5�   o   $��-401 -2 0 0q�6   $��21��6/   #��[ 6;    .  $��0 0 0 0q�6�   $��Stretch=�6�   $��Stretch=�5�      $	��160��6�   ��65   �� $ CashChequeDateStr�$ TwoWay=�$	 PropertyChanged=�.��6�   5�      5�      ]� 5�      $��5��6   $��0��6%   .+�5�      �� $	��140��6   Total Before Tax5�      5�      ]� 5�      $��5��6   $��1��6%   .+�5�      �� $��*��6   
���  ��$��1,0,1,0q�66   �� 5�      -   5        $��Amount��5�      $��0,0,0,0q�6(   " �� 	MaxLength$" 18��69   $	��230��6H   $
��Left=�6�   ��6   �� *TotalBeforeTaxStr+$ TwoWay=�$	 PropertyChanged=�.��6�    5�        5�      $ TextChanged��6)   . 5�         64   �� *TextChangedCommand+5�      .��5�   .   5�      5�      ]� 5�      $��6��6   $��0��6%   .+�5�      �� $��0,5,0,0q�65   ��6   �� *	TaxName+65   �� 5�      $��Code and Rate��6   $��5,5,0,0q�61   6D   �� 5�      -   5        $��
cmbTaxCode��5�      $��15,3,0,4q�6.   $	��100��5�      $��18��6(   $
��Left=�65   
���   �$ TaxCode��5�   L   $ TaxID��6h   $	��Top=�6�   ��5�   B   �� *
LstTaxes+
 5�   #   �� *SelectedTaxID+ 5�        5�      $ SelectionChanged��6)   . 5�         64   �� *SelectChangedCommand+5�      5�      �� 5�      $��50��6   $��26��6%   $��0,0,50,1q�61    . ��6C   �� *	TaxRate+6p   5�      ]� 5�      $��6��6   $��1��6%   .+�5�      �� $" 18��6   $��7,0,0,0q�6)   $	��230��6:    . $
��Left=�6�   ��6X   �� *TotalTaxStr+$ TwoWay=�$	 PropertyChanged=�6�   5�      ]� 5�      $��7��6   $��0��6%   .+�5�      �� $��Total After Tax��6   �� 5�      $��5,0,0,0q�6:   ��6   �� *CurrencyName+6M   5�      ]� 5�      $��7��6   $��1��6%   .+�5�      �� $" 18��6   $��7,0,0,0q�6)   $	��230��6:    . $
��Left=�6�   ��6X   �� *TotalAfterTaxStr+$ TwoWay=�$	 PropertyChanged=�6�   5�      ]� 5�      $��8��6   $��0��6%   .+�5      �� $	��140��6   	Remarks5     5     ]� 5     $��8��6   $��1��6%   .+�5     �� $	" 200��6   $��7,0,0,0q�6*   $	��230��6;   $
��Left=�6�   ��6G   �� *	Remarks+$ TwoWay=�$	 PropertyChanged=�6�   5     ]� 5     $��0��6   $��9��6(   $��2��65   .+�5     �� $,��&Enter payment of Liabilities such as, ��6   $��Italic$�6J   
�������6q   �� 5	     $��Italic$�65   
���������6   �� *	TaxName+6\   �� 5
     $;��5 paid To Government, Bank loan installments etc. here��6   $��Italic$�6Y   
�������6�   5     ]� 5     $��0��6   $��10��6(   $��2��66   .+�5     �� $"��Enter payments To Suppliers ��6   $��Italic$�6@   
�������6g   �� 5     �� 5     # �� CommandParameter$	# New��6P   $ �� Command$ 6    �� *NavigateToPaymentToSupplier+.�6g   .�5     �� $�� here ��6%   $��Italic$�63   5     5     5     ]� 5     $��0��6   $��11��6(   $��5��66   .+�5     �� $h��bIn Account Name drop-down list you can select Net GST and user created liabilities accounts only. ��6   $��Italic$�6�   
�������6�   5     �� 5     $��12��6   $��3��6&   $��Bottom=�66   $��4��6Q   $��
-200,0,0,0q�6e   
���  ����6�   �� $ PSErrors�6�   �� 5     $��12��6   $��3��6&   $��Bottom=�66   $��4��6Q   $��
-200,0,0,0q�6e   
���  ����6�   �� $ 
DateErrors�6�   ]� 5     $��12��6   $��2��6&   $��Right=�66   $��Bottom=�6R   $��3��6m   $��0 0 10 0q�6�   .+�5      �� -	   5        % ��Name$% btnNew��5      $	��New��6)   $��	10,10,0,0q�67     ButtonStyle#���  6J   $	��New��6�   ��6p   �� *NewPSCommand+6�   �� 5!     -
   5        $% btnSave��5!     $
��Save��6*   $��	10,10,0,0q�69   #���  6L   ��6r   �� *SaveCommand+6�   �� 5"     -   5        $% btnClose��5"     $��Close��6+   $��	10,10,0,0q�6;   #���  6N   ��6t   �� $ CloseCommand�6�   5#     5%     5&     5'     
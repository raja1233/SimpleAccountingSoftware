   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SASClient.Purchasing.ViewSASClient.Purchasing.View  5      3    -SASClient.Purchasing.View.StatementSubTabView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:SASClient.Purchasing.View     5      -   5          >�Name$  MyUserControll��5      $
��auto��5       $
��auto��6.   .��5	      � $
��Left=�6   $
��auto��6'    � RowDefinitions 5
   
   �� 5      $
��auto �6   6,    � ColumnDefinitions 5   
   �� 5      $��4* �6   �� 5      $��4* �6   �� 5      $��4* �6   �� 5      $��4* �6   .+�5   
   	� $��Unpaid Invoices��6C      TabMenuButtonStyle#���   6]   $��0��6�   $��10,0,0,0q�6�    d� 	IsChecked 6   �� *UnpaidInvoicesTabTrue+��5      �� *UnPaidInvoicesClickCommand+5      	� 5   
   $%��Invoices, Debit Notes, Payments��6A   #���   6l   $��1��6�   $��10,0,0,0q�6�    6   �� *InvDebPaymentTabTrue+��5      �� *InvDebitPaymentsClickCommand+5      	� 5   
   $��Payment Due Days��6B   #���   6]   $��2��6�   $��10,0,0,0q�6�    6   �� *PaymentDueDaysTabTrue+��5      �� *PaymentDueClickCommand+	� 5   
   $"��Credit days and Paid in days��6>   #���   6e   $��3��6�   $��10,0,0,0q�6�    6   �� *CreditPaidTabTrue+��5      �� *CreditPaidDaysClickCommand+5       5!      
   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SASClient.Customers.ViewsSASClient.Customers.Views  5      3    -SASClient.Customers.Views.StatementSubTabView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:SASClient.Customers.Views     5      $
��1024��5      .��5	      � $
��Left=�6   $
��auto��6'     � RowDefinitions  5
   
   �� 5      $
��auto �6   6,    � ColumnDefinitions 5   
   �� 5      $��4* �6   �� 5      $��4* �6   �� 5      $��4* �6   �� 5      $��4* �6   .+�5   
   	� $��Unpaid Invoices��6;      TabMenuButtonStyle#���   6U   $��0��6�   $��10,0,0,0q�6�    d� 	IsChecked 6   �� *UnpaidInvoice+��5      �� *UnPaidInvoicesClickCommand+5      	� 5   
   $&�� Invoices, Credit Notes, Payments��6;   #���   6g   $��1��6�   $��10,0,0,0q�6�    6   �� *InvoiceTabTrue+��5      �� *InvCreditPaymentsClickCommand+5      	� 5   
   $��Payment Due Days��6;   #���   6V   $��2��6�   $��10,0,0,0q�6�    6   �� *PaymentTabTrue+��5      �� *PaymentDueClickCommand+	� 5   
   $"��Credit days and Paid in days��6;   #���   6b   $��3��6�   $��10,0,0,0q�6�    6   �� *CreditPaidDays+��5      �� *CreditPaidDaysCommand+5       5!      
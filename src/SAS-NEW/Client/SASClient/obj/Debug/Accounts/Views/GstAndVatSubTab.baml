   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SASClient.Accounts.ViewsSASClient.Accounts.Views  5      .    (SASClient.Accounts.Views.GstAndVatSubTab   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:SASClient.Accounts.Views     5      $
��1024��5      .��5	      � $
��Left=�6   $
��auto��6'     � RowDefinitions  5
   
   �� 5      $
��auto �6   6,    � ColumnDefinitions 5   
   �� 5      $��4* �6   �� 5      $��4* �6   �� 5      $��4* �6   �� 5      $��4* �6   .+�5   
   	� $��Tax Summary��6?      TabMenuButtonStyle#���   6U   $��0��6�   $��10,5,0,0q�6�    d� 	IsChecked 6   �� *GstSummarytabTrue+��5      �� *ShowTaxSummaryCommand+5      	� 5   
   $��Tax Collected Details��6@   #���   6a   $��1��6�   $��10,5,0,0q�6�    6   �� *GstCollectedtabTrue+��5      �� *ShowTaxCollectedCommand+5      	� 5   
   $��Tax Paid Details��6;   #���   6V   $��2��6�   $��10,5,0,0q�6�    6   �� *GstPaidtabTrue+��5      �� *ShowTaxPaidDetailsCommand+5      5      
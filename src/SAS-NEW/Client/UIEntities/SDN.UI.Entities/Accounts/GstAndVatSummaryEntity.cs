﻿using SDN.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Accounts
{
    public class GstAndVatSummaryEntity : ViewModelBase
    {
        #region
        private bool? _GstSummarytabTrue;
        private bool? _GstPaidtabTrue;
        private bool? _GstCollectedtabTrue;

        private int _SIGridHeightSummary;
        private int _SIGridHeightCollected;
        private int _SIGridHeightPaid;
        private bool? _EnableYearDropDown;
        private bool? _EnableQuarterDropDown;
        private bool? _EnableMonthDropDown;
        private bool isSelected;
        private string _JsonData;
        private int? _ID;
        private string _SelectedSearchYear;
        private string _SelectedSearchQuarter;
        private string _SelectedSearchMonth;
        private bool? _ShowSelectedTrue;
        private bool? _YearmonthQuartTrue;
        private bool? _ShowTaxCollectedTrue;
        private bool? _ShowSummaryTrue;
        private bool? _ShowTaxPaidDetailTrue;
        private List<YearEntity> _YearRange;
        private bool? _TaxSummaryTrue;
        private bool? _TaxCollectedTrue;
        private bool? _TaxPaidDetailsTrue;
        private string _currencyFormat;
        private decimal? _decimalPlaces;
        private string _DateFormat;
        private string _currencyName;
        private string _currencyCode;
        // Entity for Tax Paid
        private string _TaxDescriptionS;
        private string _TaxCodeS;
        private string _TaxRateS;
        private string _SuppliersName;
        private string _TaxInvoiceNoS;
        private string _TaxDateS;
        private string _TaxInvoiceAmountStrS;
        private decimal? _TaxInvoiceAmountS;
        private string _TaxCollectedStrS;
        private decimal? _TaxCollectedS;
        private string _TotalTaxInvoiceAmountS;
        private string _TotalTaxCollectedS;
        //End Entity for Tax Paid
        // Entity for tax Collected
        private string _TaxDescriptionC;
        private string _TaxCodeC;
        private string _TaxRateC;
        private string _CustomersName;
        private string _TaxInvoiceNoC;
        private string _TaxDateC;
        private decimal? _TaxInvoiceAmountC;
        private decimal? _TaxCollectedC;
        private string _TaxInvoiceAmountStrC;
        private string _TaxCollectedStrC;
       
        private string _TotalTaxCollecetdC;
        //end Entity for tax collecetd
        //Tax Summary Entity
        private string _TaxDescriptionSummary;
        private string _TaxCodeSummary;
        private string  _TaxRateSummary;
        private string _TaxInvoiceCNAmountSummary;
        private string _TaxCollectedSummary;
        private string _TaxInvoiceDNAmountSummary;
        private string _TaxPaidSummary;
        private string _TotalTaxInvoiceCNAmountSummary;
        private string _TotalTaxCollectedSummary;
        private string _TotalInvoiceDNAmountSummary;
        private string _TotalPaidSummary;
        private decimal? _TaxInvoiceCNAmountSummaryDec;
        private decimal? _TaxCollectedSummaryDec;
        private decimal? _TaxInvoiceDNAmountSummaryDec;
        private decimal? _TaxPaidSummaryDec;
        // End Tax Summary Entity
        //all proprty
        private bool? _ShowAllTrue;
        private int? _ShowSelectedCount;
        private string totalInvoiceAmount;
        private string totalTaxCollecetdAmount;
        private string totalDnAmount;
        private string totaltaxPaid;
       
        private List<GstAndVatSummaryEntity> _GstAndVatPaidEntityList;
        private List<GstAndVatSummaryEntity> _GstAndVatCollectedEntityList;
        private List<GstAndVatSummaryEntity> _GstAndVatSummaryEntityList;
        
        #endregion
        #region public entity
        public bool? ShowAllTrue
        {
            get
            {
                return _ShowAllTrue;
            }
            set
            {
                _ShowAllTrue = value;
                OnPropertyChanged("ShowAllTrue");
            }
        }

        public string TotalTaxCollecetdAmount
        {
            get
            {
                //return _InvoiceAmount;
                if (totalTaxCollecetdAmount == null)
                    return this.totalTaxCollecetdAmount;
                else
                {
                    if (totalTaxCollecetdAmount != "")
                    {
                        var balance = totalTaxCollecetdAmount.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.totalTaxCollecetdAmount;
                }
            }
            set
            {
                totalTaxCollecetdAmount = value;
                OnPropertyChanged("TotalInvoiceAmount");
            }
        }
        public string TotalDnAmount
        {
            get
            {
                //return _InvoiceAmount;
                if (totalDnAmount == null)
                    return this.totalDnAmount;
                else
                {
                    if (totalDnAmount != "")
                    {
                        var balance = totalDnAmount.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.totalDnAmount;
                }
            }
            set
            {
                totalDnAmount = value;
                OnPropertyChanged("TotalInvoiceAmount");
            }
        }
        public string TotaltaxPaid
        {
            get
            {
                //return _InvoiceAmount;
                if (totaltaxPaid == null)
                    return this.totaltaxPaid;
                else
                {
                    if (totaltaxPaid != "")
                    {
                        var balance = totaltaxPaid.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.totaltaxPaid;
                }
            }
            set
            {
                totalTaxCollecetdAmount = value;
                OnPropertyChanged("TotalInvoiceAmount");
            }
        }
        public string TotalInvoiceAmount
        {
            get
            {
                //return _InvoiceAmount;
                if (totalInvoiceAmount == null)
                    return this.totalInvoiceAmount;
                else
                {
                    if (totalInvoiceAmount != "")
                    {
                        var balance = totalInvoiceAmount.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.totalInvoiceAmount;
                }
            }
            set
            {
                totalInvoiceAmount = value;
                OnPropertyChanged("TotalInvoiceAmount");
            }
        }
        public int? ShowSelectedCount
        {
            get
            {
                return _ShowSelectedCount;
            }
            set
            {
                _ShowSelectedCount = value;
                OnPropertyChanged("ShowSelectedCount");
            }
        }
        public List<GstAndVatSummaryEntity> GstAndVatPaidEntityList
        {
            get
            {
                return _GstAndVatPaidEntityList;
            }
            set
            {
                _GstAndVatPaidEntityList = value;
                OnPropertyChanged("GstAndVatPaidEntityList");
            }
        }
        public List<GstAndVatSummaryEntity> GstAndVatCollectedEntityList
        {
            get
            {
                return _GstAndVatCollectedEntityList;
            }
            set
            {
                _GstAndVatCollectedEntityList = value;
                OnPropertyChanged("GstAndVatCollectedEntityList");
            }
        }
        public List<GstAndVatSummaryEntity> GstAndVatSummaryEntityList
        {
            get
            {
                return _GstAndVatSummaryEntityList;
            }
            set
            {
                _GstAndVatSummaryEntityList = value;
                OnPropertyChanged("GstAndVatSummaryEntityList");
            }
        }
        #region "Subtab entity"
         
        public bool? GstSummarytabTrue
        {
            get
            {
                return _GstSummarytabTrue;
            }
            set
            {
                _GstSummarytabTrue = value;
                OnPropertyChanged("GstSummarytabTrue");
            }
        }
        public bool? GstPaidtabTrue
        {
            get
            {
                return _GstPaidtabTrue;
            }
            set
            {
                _GstPaidtabTrue = value;
                OnPropertyChanged("GstPaidtabTrue");
            }
        }
        public bool? GstCollectedtabTrue
        {
            get
            {
                return _GstCollectedtabTrue;
            }
            set
            {
                _GstCollectedtabTrue = value;
                OnPropertyChanged("GstCollectedtabTrue");
            }
        }
        #endregion

        #region "summary"
        public string TaxPaidSummary
        {
            get
            {
                return _TaxPaidSummary;
            }
            set
            {
                _TaxPaidSummary = value;
                OnPropertyChanged("TaxPaidSummary");
            }
        }
        public string TaxInvoiceDNAmountSummary
        {
            get
            {
                return _TaxInvoiceDNAmountSummary;
            }
            set
            {
                _TaxInvoiceDNAmountSummary = value;
                OnPropertyChanged("TaxInvoiceDNAmountSummary");
            }
        }

        public string TaxCollectedSummary
        {
            get
            {
                return _TaxCollectedSummary;
            }
            set
            {
                _TaxCollectedSummary = value;
                OnPropertyChanged("TaxCollectedSummary");
            }
        }

        public string TaxInvoiceCNAmountSummary
        {
            get
            {
                return _TaxInvoiceCNAmountSummary;
            }
            set
            {
                _TaxInvoiceCNAmountSummary = value;
                OnPropertyChanged("TaxInvoiceCNAmountSummary");
            }
        }
        public string TaxRateSummary
        {
            get
            {
                return _TaxRateSummary;
            }
            set
            {
                _TaxRateSummary = value;
                OnPropertyChanged("TaxRateSummary");
            }
        }
        public string TaxCodeSummary
        {
            get
            {
                return _TaxCodeSummary;
            }
            set
            {
                _TaxCodeSummary = value;
                OnPropertyChanged("TaxCodeSummary");
            }
        }
        public string TaxDescriptionSummary
        {
            get
            {
                return _TaxDescriptionSummary;
            }
            set
            {
                _TaxDescriptionSummary = value;
                OnPropertyChanged("TaxDescriptionSummary");
            }
        }
        public string TotalTaxInvoiceCNAmountSummary
        {
            get
            {
                //return _QuotationAmount;
                if (_TotalTaxInvoiceCNAmountSummary == null)
                    return this._TotalTaxInvoiceCNAmountSummary;
                else
                {
                    if (_TotalTaxInvoiceCNAmountSummary != "")
                    {
                        var balance = _TotalTaxInvoiceCNAmountSummary.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this._TotalTaxInvoiceCNAmountSummary;
                }
            }
            set
            {
                _TotalTaxInvoiceCNAmountSummary = value;
                OnPropertyChanged("TotalTaxInvoiceCNAmountSummary");
            }
        }
        public string TotalTaxCollectedSummary
        {
            get
            {
                //return _QuotationAmount;
                if (_TotalTaxCollectedSummary == null)
                    return this._TotalTaxCollectedSummary;
                else
                {
                    if (_TotalTaxCollectedSummary != "")
                    {
                        var balance = _TotalTaxCollectedSummary.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this._TotalTaxCollectedSummary;
                }
            }
            set
            {
                _TotalTaxCollectedSummary = value;
                OnPropertyChanged("TotalTaxCollectedSummary");
            }
        }
        public string TotalInvoiceDNAmountSummary
        {
            get
            {
                //return _QuotationAmount;
                if (_TotalInvoiceDNAmountSummary == null)
                    return this._TotalInvoiceDNAmountSummary;
                else
                {
                    if (_TotalInvoiceDNAmountSummary != "")
                    {
                        var balance = _TotalInvoiceDNAmountSummary.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this._TotalInvoiceDNAmountSummary;
                }
            }
            set
            {
                _TotalInvoiceDNAmountSummary = value;
                OnPropertyChanged("TotalInvoiceDNAmountSummary");
            }
        }
        public string TotalPaidSummary
        {
            get
            {
                //return _QuotationAmount;
                if (_TotalPaidSummary == null)
                    return this._TotalPaidSummary;
                else
                {
                    if (_TotalPaidSummary != "")
                    {
                        var balance = _TotalPaidSummary.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this._TotalPaidSummary;
                }
            }
            set
            {
                _TotalPaidSummary = value;
                OnPropertyChanged("TotalPaidSummary");
            }
        }

        public decimal? TaxInvoiceCNAmountSummaryDec
        {
            get
            {
                return _TaxInvoiceCNAmountSummaryDec;
            }
            set
            {
                _TaxInvoiceCNAmountSummaryDec = value;
                OnPropertyChanged("TaxInvoiceCNAmountSummaryDec");
            }
        }
        public decimal? TaxCollectedSummaryDec
        {
            get
            {
                return _TaxCollectedSummaryDec;
            }
            set
            {
                _TaxCollectedSummaryDec = value;
                OnPropertyChanged("TaxCollectedSummaryDec");
            }
        }
        public decimal? TaxInvoiceDNAmountSummaryDec
        {
            get
            {
                return _TaxInvoiceDNAmountSummaryDec;
            }
            set
            {
                _TaxInvoiceDNAmountSummaryDec = value;
                OnPropertyChanged("TaxInvoiceDNAmountSummaryDec");
            }
        }
        public decimal? TaxPaidSummaryDec
        {
            get
            {
                return _TaxPaidSummaryDec;
            }
            set
            {
                _TaxPaidSummaryDec = value;
                OnPropertyChanged("TaxPaidSummaryDec");
            }
        }
        #endregion
        public string TaxDescriptionC
        {
            get
            {
                return _TaxDescriptionC;
            }
            set
            {
                _TaxDescriptionC = value;
                OnPropertyChanged("TaxDescriptionC");
            }
        }
        public string TaxCodeC
        {
            get
            {
                return _TaxCodeC;
            }
            set
            {
                _TaxCodeC = value;
                OnPropertyChanged("TaxCodeC");
            }
        }
        public string TaxRateC
        {
            get
            {
                return _TaxRateC;
            }
            set
            {
                _TaxRateC = value;
                OnPropertyChanged("TaxRateC");
            }
        }
        public string CustomersName
        {
            get
            {
                return _CustomersName;
            }
            set
            {
                _CustomersName = value;
                OnPropertyChanged("CustomersName");
            }
        }
        public string TaxInvoiceNoC
        {
            get
            {
                return _TaxInvoiceNoC;
            }
            set
            {
                _TaxInvoiceNoC = value;
                OnPropertyChanged("TaxInvoiceNoC");
            }
        }
        public string TaxDateC
        {
            get
            {
                return _TaxDateC;
            }
            set
            {
                _TaxDateC = value;
                OnPropertyChanged("TaxDateC");
            }
        }
        public decimal? TaxInvoiceAmountC
        {
            get
            {
                return _TaxInvoiceAmountC;
            }
            set
            {
                _TaxInvoiceAmountC = value;
                OnPropertyChanged("TaxInvoiceAmountC");
            }
        }
        public string TaxInvoiceAmountStrC
        {
            get
            {
                return _TaxInvoiceAmountStrC;
            }
            set
            {
                _TaxInvoiceAmountStrC = value;
                OnPropertyChanged("TaxInvoiceAmountStrC");
            }
        }
        public decimal? TaxCollectedC
        {
            get
            {
                return _TaxCollectedC;
            }
            set
            {
                _TaxCollectedC = value;
                OnPropertyChanged("TaxCollectedC");
            }
        }
        public string TaxCollectedStrC
        {
            get
            {
                return _TaxCollectedStrC;
            }
            set
            {
                _TaxCollectedStrC = value;
                OnPropertyChanged("TaxCollectedStrC");
            }
        }
      
        public string TotalTaxCollecetdC
        {
            get
            {
                //return _QuotationAmount;
                if (_TotalTaxCollecetdC == null)
                    return this._TotalTaxCollecetdC;
                else
                {
                    if (_TotalTaxCollecetdC != "")
                    {
                        var balance = _TotalTaxCollecetdC.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this._TotalTaxCollecetdC;
                }
            }
            set
            {
                _TotalTaxCollecetdC = value;
                OnPropertyChanged("TotalTaxCollecetdC");
            }
        }
        public string TaxInvoiceAmountStrS
        {
            get
            {

                return _TaxInvoiceAmountStrS;
            }
            set
            {
                _TaxInvoiceAmountStrS = value;
                OnPropertyChanged("TaxInvoiceAmountStrS");
            }
        }
        public string TaxDescriptionS

        {
            get
            {
                return _TaxDescriptionS;
            }
            set
            {
                _TaxDescriptionS = value;
                OnPropertyChanged("TaxDescriptionS");
            }
        }
        public string TaxCodeS
        {
            get
            {
                return _TaxCodeS;
            }
            set
            {
                _TaxCodeS = value;
                OnPropertyChanged("TaxCodeS");
            }
        }
        public string TaxRateS
        {
            get
            {
                return _TaxRateS;
            }
            set
            {
                _TaxRateS = value;
                OnPropertyChanged("TaxRateS");
            }
        }
        public string SuppliersName
        {
            get
            {
                return _SuppliersName;
            }
            set
            {
                _SuppliersName = value;
                OnPropertyChanged("SuppliersName");
            }
        }
        public string TaxInvoiceNoS
        {
            get
            {
                return _TaxInvoiceNoS;
            }
            set
            {
                _TaxInvoiceNoS = value;
                OnPropertyChanged("TaxInvoiceNoS");
            }
        }
        public string TaxDateS
        {
            get
            {
                return _TaxDateS;
            }
            set
            {
                _TaxDateS = value;
                OnPropertyChanged("TaxDateS");
            }
        }
        public decimal? TaxInvoiceAmountS
        {
            get
            {
                return _TaxInvoiceAmountS;
            }
            set
            {
                _TaxInvoiceAmountS = value;
                OnPropertyChanged("TaxInvoiceAmountS");
            }
        }
        public string TaxCollectedStrS
        {
            get
            {
                return _TaxCollectedStrS;
            }
            set
            {
                _TaxCollectedStrS = value;
                OnPropertyChanged("TaxCollectedStrS");
            }
        }
        public decimal? TaxCollectedS
        {
            get
            {
                return _TaxCollectedS;
            }
            set
            {
                _TaxCollectedS = value;
                OnPropertyChanged("TaxCollectedS");
            }
        }
        public string TotalTaxInvoiceAmountS
        {
            get
            {
                //return _QuotationAmount;
                if (_TotalTaxInvoiceAmountS == null)
                    return this._TotalTaxInvoiceAmountS;
                else
                {
                    if (_TotalTaxInvoiceAmountS != "")
                    {
                        var balance = _TotalTaxInvoiceAmountS.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this._TotalTaxInvoiceAmountS;
                }
            }
            set
            {
                _TotalTaxInvoiceAmountS = value;
                OnPropertyChanged("TotalTaxInvoiceAmountS");
            }
        }
        public string TotalTaxCollectedS
        {
            get
            {
                //return _QuotationAmount;
                if (_TotalTaxCollectedS == null)
                    return this._TotalTaxCollectedS;
                else
                {
                    if (_TotalTaxCollectedS != "")
                    {
                        var balance = _TotalTaxCollectedS.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this._TotalTaxCollectedS;
                }
            }
            set
            {
                _TotalTaxCollectedS = value;
                OnPropertyChanged("TotalTaxCollectedS");
            }
        }
        public decimal? DecimalPlaces
        {
            get { return _decimalPlaces; }

            set
            {
                if (_decimalPlaces != value)
                {
                    _decimalPlaces = value;
                    OnPropertyChanged("DecimalPlaces");
                }
            }
        }
        public string DateFormat
        {
            get { return _DateFormat; }
            set { SetProperty(ref _DateFormat, value, "DateFormat"); }
        }
        public string CurrencyName
        {
            get
            {
                return _currencyName;
            }
            set
            {

                if (_currencyName != value)
                {
                    _currencyName = value;
                    OnPropertyChanged("CurrencyName");
                }
            }
        }
        public string CurrencyCode
        {
            get { return _currencyCode; }

            set
            {
                if (_currencyCode != value)
                {
                    _currencyCode = value;
                    OnPropertyChanged("CurrencyCode");
                }
            }
        }
        public string CurrencyFormat
        {
            get { return _currencyFormat; }

            set
            {
                if (_currencyFormat != value)
                {
                    _currencyFormat = value;
                    OnPropertyChanged("CurrencyFormat");
                }
            }
        }
        public int SIGridHeightSummary
        {
            get
            {
                return _SIGridHeightSummary;
            }
            set
            {
                _SIGridHeightSummary = value;
                OnPropertyChanged("SIGridHeightSummary");
            }
        }
        public int SIGridHeightCollected
        {
            get
            {
                return _SIGridHeightCollected;
            }
            set
            {
                _SIGridHeightCollected = value;
                OnPropertyChanged("SIGridHeightCollected");
            }
        }
        public int SIGridHeightPaid
        {
            get
            {
                return _SIGridHeightPaid;
            }
            set
            {
                _SIGridHeightPaid = value;
                OnPropertyChanged("SIGridHeightPaid");
            }
        }
        public bool? EnableYearDropDown
        {
            get
            {
                return _EnableYearDropDown;
            }
            set
            {
                _EnableYearDropDown = value;
                OnPropertyChanged("EnableYearDropDown");
            }
        }
        public bool? EnableQuarterDropDown
        {
            get
            {
                return _EnableQuarterDropDown;
            }
            set
            {
                _EnableQuarterDropDown = value;
                OnPropertyChanged("EnableQuarterDropDown");
            }
        }
        public string JsonData
        {
            get
            {
                return _JsonData;
            }
            set
            {
                _JsonData = value;
                OnPropertyChanged("JsonData");
            }
        }

        public bool? EnableMonthDropDown
        {
            get
            {
                return _EnableMonthDropDown;
            }
            set
            {
                _EnableMonthDropDown = value;
                OnPropertyChanged("EnableMonthDropDown");
            }
        }
        public bool? ShowSelectedTrue
        {
            get
            {
                return _ShowSelectedTrue;
            }
            set
            {
                _ShowSelectedTrue = value;
                OnPropertyChanged("ShowSelectedTrue");
            }
        }

        public bool? YearmonthQuartTrue
        {
            get
            {
                return _YearmonthQuartTrue;
            }
            set
            {
                _YearmonthQuartTrue = value;
                if (_YearmonthQuartTrue == true)
                {
                    //SelectedSearchStartDate = null;
                    //SelectedSearchEndDate = null;
                    //EnableEndDropDown = false;
                    //EnableStartDropDown = false;
                    EnableMonthDropDown = true;
                    EnableQuarterDropDown = true;
                    EnableYearDropDown = true;

                }

                OnPropertyChanged("YearmonthQuartTrue");
            }
        }
        public int? ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
                OnPropertyChanged("ID");
            }
        }

        public List<YearEntity> YearRange
        {
            get
            {
                return _YearRange;
            }
            set
            {
                _YearRange = value;
                OnPropertyChanged("YearRange");
            }
        }
        public string SelectedSearchYear
        {
            get
            {
                return _SelectedSearchYear;
            }
            set
            {
                _SelectedSearchYear = value;
                OnPropertyChanged("SelectedSearchYear");
            }
        }
        public string SelectedSearchQuarter
        {
            get
            {
                return _SelectedSearchQuarter;
            }
            set
            {
                _SelectedSearchQuarter = value;
                //if (_SelectedSearchQuarter != null)
                //SelectedSearchMonth = null;
                OnPropertyChanged("SelectedSearchQuarter");
            }
        }
        public string SelectedSearchMonth
        {
            get
            {
                return _SelectedSearchMonth;
            }
            set
            {
                _SelectedSearchMonth = value;
                if (_SelectedSearchMonth != null)
                    SelectedSearchQuarter = null;
                OnPropertyChanged("SelectedSearchMonth");
            }
        }
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }


        public bool? ShowTaxCollectedTrue
        {
            get { return _ShowTaxCollectedTrue; }
            set
            {
                _ShowTaxCollectedTrue = value;
                OnPropertyChanged("ShowTaxCollectedTrue");
            }
        }
        public bool? ShowTaxPaidDetailTrue
        {
            get { return _ShowTaxPaidDetailTrue; }
            set
            {
                _ShowTaxPaidDetailTrue = value;
                OnPropertyChanged("ShowTaxPaidDetailTrue");
            }
        }
        public bool? ShowSummaryTrue
        {
            get { return _ShowSummaryTrue; }
            set
            {
                _ShowSummaryTrue = value;
                OnPropertyChanged("ShowSummaryTrue");
            }
        }

        public bool? TaxSummaryTrue
        {
            get { return _TaxSummaryTrue; }
            set
            {
                _TaxSummaryTrue = value;
                OnPropertyChanged("TaxSummaryTrue");
            }
        }
        public bool? TaxCollectedTrue
        {
            get { return _TaxCollectedTrue; }
            set
            {
                _TaxCollectedTrue = value;
                OnPropertyChanged("TaxCollectedTrue");
            }
        }
        public bool? TaxPaidDetailsTrue
        {
            get { return _TaxPaidDetailsTrue; }
            set
            {
                _TaxPaidDetailsTrue = value;
                OnPropertyChanged("TaxPaidDetailsTrue");
            }
        }
        #endregion
    }
}

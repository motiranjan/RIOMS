using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RIOMS.Domain;
namespace RIOMS.WebUI.Models
{
    public class DCBViewModel
    {

        public DCBViewModel(Village village, ICollection<IForm> argiforms)
        {
            Village = village;
            iforms=argiforms;
            for (int i = 0; i < iforms.Count;i++ )
            {
                var iform = iforms.ElementAt(i);
                if (iform.IFormDetailCesses.Count + iform.IFormDetailLandRevenues.Count + iform.IFormDetailWaterTaxes.Count > 0)
                {
                    if (iform.IFormDetailCesses.Count == 0)
                    {
                        iform.IFormDetailCesses.Add(new IFormDetailCess());
                    }
                    if (iform.IFormDetailLandRevenues.Count == 0)
                    {
                        iform.IFormDetailLandRevenues.Add(new IFormDetailLandRevenue());
                    }
                    if (iform.IFormDetailWaterTaxes.Count == 0)
                    {
                        iform.IFormDetailWaterTaxes.Add(new IFormDetailWaterTax());
                    }
                }
                else
                {
                    iforms.Remove(iform);
                    i--;
                }
            }
           
           
            
        }
      
        public DCBViewModel(Village village)
        {
            Village = village;
        }
        public IEnumerable<CollectionMovementCess> GoToVillagesCess
        {
            get { return Village.CollectionMovementCessesTo; }
        
        }
     public VillageWiseTahCollectionCess TahCollectionCess
        {
            get
            {
                if (Village.VillageWiseTahCollectionCesses.Count>0)
                {
                    return Village.VillageWiseTahCollectionCesses.ElementAt(0);
                }
                else
                {
                    return new VillageWiseTahCollectionCess();
                }
            }
        }
     public VillageWiseTahCollectionWaterTax TahCollectionWaterTax
     {
         get
         {
             if (Village.VillageWiseTahCollectionWaterTaxes.Count > 0)
             {
                 return Village.VillageWiseTahCollectionWaterTaxes.ElementAt(0);
             }
             else
             {
                 return new VillageWiseTahCollectionWaterTax();
             }
         }
     }
     public bool HasTahCollection
     {
         get
         {
             return (Village.VillageWiseTahCollectionLandRevenues.Count + Village.VillageWiseTahCollectionWaterTaxes.Count + Village.VillageWiseTahCollectionCesses.Count > 0);
         }
     }
     public VillageWiseTahCollectionLandRevenue TahCollectionLanadRevenue
     {
         get
         {
             if (Village.VillageWiseTahCollectionLandRevenues.Count > 0)
             {
                 return Village.VillageWiseTahCollectionLandRevenues.ElementAt(0);
             }
             else
             {
                 return new VillageWiseTahCollectionLandRevenue();
             }
         }
     }
        public IEnumerable<CollectionMovementCess> ComeFromVillagesCess
        {
            get { return Village.CollectionMovementCessesFrom; }

        }
        private ICollection<IForm> iforms;

        public ICollection<IForm> IForms
        {
            get { return iforms; }
            
        }
        
        public Village Village { get; set; }

        public AdvanceAdjustmentCess AdvanceAdjustmentCess
        {
            get
            {
                return new AdvanceAdjustmentCess
                {
                    Current = Village.AdvanceAdjustmentCesses.Sum(aj => aj.Current)
                };
            }
        }
        public AdvanceAdjustmentWaterTax AdvanceAdjustmentWaterTax
        {
            get
            {
                return new AdvanceAdjustmentWaterTax
                {
                    Current = Village.AdvanceAdjustmentWaterTaxes.Sum(aj => aj.Current)
                };
            }
        }
        public DemandCess ActualDemandCess
        {
            get
            {
                return new DemandCess
                {
                    MoreThanThree = Village.DemandCesses.Sum(a => a.MoreThanThree),
                    Third = Village.DemandCesses.Sum(a => a.Third),
                    Second = Village.DemandCesses.Sum(a => a.Second),
                    Previous = Village.DemandCesses.Sum(a => a.Previous),
                    Current = Village.DemandCesses.Sum(a => a.Current),
                    Advance=Village.DemandCesses.Sum(a=>a.Advance)
                };
            }
        }
        public DemandLandRevenue ActualDemandLandRevenue
        {
            get
            {
                if (Village.DemandLandRevenues.Count > 0)
                {

                    return new DemandLandRevenue
                    {
                        MoreThanThree = Village.DemandLandRevenues.Sum(a => a.MoreThanThree),
                        Third = Village.DemandLandRevenues.Sum(a => a.Third),
                        Second = Village.DemandLandRevenues.Sum(a => a.Second),
                        Previous = Village.DemandLandRevenues.Sum(a => a.Previous),
                        Current = Village.DemandLandRevenues.Sum(a => a.Current),
                        Advance = Village.DemandLandRevenues.Sum(a => a.Advance)
                    };
                }
                else
                {
                    return new DemandLandRevenue();
                }
            }
        }
        public DemandWaterTax ActualDemandWaterTax
        {
            get
            {
                if (Village.DemandWaterTaxes.Count>0)
                {

                    return new DemandWaterTax
                    {
                        MoreThanThree = Village.DemandWaterTaxes.Sum(a => a.MoreThanThree),
                        Third = Village.DemandWaterTaxes.Sum(a => a.Third),
                        Second = Village.DemandWaterTaxes.Sum(a => a.Second),
                        Previous = Village.DemandWaterTaxes.Sum(a => a.Previous),
                        Current = Village.DemandWaterTaxes.Sum(a => a.Current),
                        Advance = Village.DemandWaterTaxes.Sum(a => a.Advance)
                    }; 
                }
                else
                {
                    return new DemandWaterTax();
                }
            }
        }

        public DemandCess DemandCess
        {
            get
            {
                return new DemandCess
                {
                    MoreThanThree = Village.VillageWiseDemandCesses.Sum(a => a.MoreThanThree),
                    Third = Village.VillageWiseDemandCesses.Sum(a => a.Third),
                    Second = Village.VillageWiseDemandCesses.Sum(a => a.Second),
                    Previous = Village.VillageWiseDemandCesses.Sum(a => a.Previous),
                    Current = Village.VillageWiseDemandCesses.Sum(a => a.Current),
                    Advance = Village.VillageWiseDemandCesses.Sum(a => a.Advance),
                    Increase = Village.VillageWiseDemandCesses.Sum(a => a.Increase)
                };
            }
        }
        public DemandLandRevenue DemandLandRevenue
        {
            get
            {
                if (Village.DemandLandRevenues.Count > 0)
                {

                    return new DemandLandRevenue
                    {
                        MoreThanThree = Village.VillageWiseDemandLandRevenues.Sum(a => a.MoreThanThree),
                        Third = Village.VillageWiseDemandLandRevenues.Sum(a => a.Third),
                        Second = Village.VillageWiseDemandLandRevenues.Sum(a => a.Second),
                        Previous = Village.VillageWiseDemandLandRevenues.Sum(a => a.Previous),
                        Current = Village.VillageWiseDemandLandRevenues.Sum(a => a.Current),
                        Advance = Village.VillageWiseDemandLandRevenues.Sum(a => a.Advance),
                        Increase = Village.VillageWiseDemandLandRevenues.Sum(a => a.Increase)
                    };
                }
                else
                {
                    return new DemandLandRevenue();
                }
            }
        }
        public DemandWaterTax DemandWaterTax
        {
            get
            {
                if (Village.DemandWaterTaxes.Count > 0)
                {

                    return new DemandWaterTax
                    {
                        MoreThanThree = Village.VillageWiseDemandWaterTaxes.Sum(a => a.MoreThanThree),
                        Third = Village.VillageWiseDemandWaterTaxes.Sum(a => a.Third),
                        Second = Village.VillageWiseDemandWaterTaxes.Sum(a => a.Second),
                        Previous = Village.VillageWiseDemandWaterTaxes.Sum(a => a.Previous),
                        Current = Village.VillageWiseDemandWaterTaxes.Sum(a => a.Current),
                        Advance = Village.VillageWiseDemandWaterTaxes.Sum(a => a.Advance)
                    };
                }
                else
                {
                    return new DemandWaterTax();
                }
            }
        }


        public decimal IncreaseInDemandCess
        {
            get
            {
                return Village.VillageWiseDemandCesses.ElementAt(0).Increase;
            }
        }
        public decimal IncreaseInDemandLandRevenue
        {
            get
            {
                if (Village.VillageWiseDemandLandRevenues.Count>0)
                {
                    return Village.VillageWiseDemandLandRevenues.ElementAt(0).Increase; 
                }
                else
                {
                    return 0;
                }
            }
        }
        public DemandCess NetDemandCess
        {
            get
            {
                return new DemandCess
                {
                    MoreThanThree = Village.VillageWiseDemandCesses.ElementAt(0).MoreThanThree,
                    Third = Village.VillageWiseDemandCesses.ElementAt(0).Third,
                    Second = Village.VillageWiseDemandCesses.ElementAt(0).Second,
                    Previous = Village.VillageWiseDemandCesses.ElementAt(0).Previous,
                    Current = (Village.VillageWiseDemandCesses.ElementAt(0).Current + Village.VillageWiseDemandCesses.ElementAt(0).Increase) - AdvanceAdjustmentCess.Current.GetValueOrDefault(),
                    Advance = (Village.VillageWiseDemandCesses.ElementAt(0).Advance - AdvanceAdjustmentCess.Current.GetValueOrDefault())
                };
            }
        }
     
        public DemandWaterTax NetDemandWaterTax
        {
            get
            {
                if (Village.VillageWiseDemandWaterTaxes.Count>0)
                {
                    return new DemandWaterTax
                            {
                                MoreThanThree = Village.VillageWiseDemandWaterTaxes.ElementAt(0).MoreThanThree,
                                Third = Village.VillageWiseDemandWaterTaxes.ElementAt(0).Third,
                                Second = Village.VillageWiseDemandWaterTaxes.ElementAt(0).Second,
                                Previous = Village.VillageWiseDemandWaterTaxes.ElementAt(0).Previous,
                                Current = Village.VillageWiseDemandWaterTaxes.ElementAt(0).Current - AdvanceAdjustmentWaterTax.Current.GetValueOrDefault(),
                                Advance = Village.VillageWiseDemandWaterTaxes.ElementAt(0).Advance - AdvanceAdjustmentWaterTax.Current.GetValueOrDefault()
                            }; 
                }
                else
                {
                    return new DemandWaterTax();
                }
            }
        }
        public DemandLandRevenue NetDemandLandRevenue
        {
            get
            {
                if (Village.VillageWiseDemandLandRevenues.Count > 0)
                {
                    return new DemandLandRevenue
                    {
                        MoreThanThree = Village.VillageWiseDemandLandRevenues.ElementAt(0).MoreThanThree,
                        Third = Village.VillageWiseDemandLandRevenues.ElementAt(0).Third,
                        Second = Village.VillageWiseDemandLandRevenues.ElementAt(0).Second,
                        Previous = Village.VillageWiseDemandLandRevenues.ElementAt(0).Previous,
                        Current = Village.VillageWiseDemandLandRevenues.ElementAt(0).Current + Village.VillageWiseDemandLandRevenues.ElementAt(0).Increase,
                        Advance = Village.VillageWiseDemandLandRevenues.ElementAt(0).Advance 
                    };
                }
                else
                {
                    return new DemandLandRevenue();
                }
            }
        }
        public CollectionCess TotalCollectionCess
        {
            get
            {
                return new CollectionCess
                {
                    MoreThanThree=Village.IFormDetailCesses.Sum(c=>c.MoreThanThree).GetValueOrDefault(),
                    Third = Village.IFormDetailCesses.Sum(c => c.Third).GetValueOrDefault(),
                    Second = Village.IFormDetailCesses.Sum(c => c.Second).GetValueOrDefault(),
                    Previous = Village.IFormDetailCesses.Sum(c => c.Previous).GetValueOrDefault(),
                    Current = Village.IFormDetailCesses.Sum(c => c.Current).GetValueOrDefault()
                    
                };
            }
        }
        public CollectionWaterTax TotalCollectionWaterTax
        {
            get
            {
                return new CollectionWaterTax
                {
                    MoreThanThree = Village.IFormDetailWaterTaxes.Sum(c => c.MoreThanThree).GetValueOrDefault(),
                    Third = Village.IFormDetailWaterTaxes.Sum(c => c.Third).GetValueOrDefault(),
                    Second = Village.IFormDetailWaterTaxes.Sum(c => c.Second).GetValueOrDefault(),
                    Previous = Village.IFormDetailWaterTaxes.Sum(c => c.Previous).GetValueOrDefault(),
                    Current = Village.IFormDetailWaterTaxes.Sum(c => c.Current).GetValueOrDefault()

                };
            }
        }
        public CollectionLandRevenue TotalCollectionLandRevenue
        {
            get
            {
                return new CollectionLandRevenue
                {
                    MoreThanThree = Village.IFormDetailLandRevenues.Sum(c => c.MoreThanThree).GetValueOrDefault(),
                    Third = Village.IFormDetailLandRevenues.Sum(c => c.Third).GetValueOrDefault(),
                    Second = Village.IFormDetailLandRevenues.Sum(c => c.Second).GetValueOrDefault(),
                    Previous = Village.IFormDetailLandRevenues.Sum(c => c.Previous).GetValueOrDefault(),
                    Current = Village.IFormDetailLandRevenues.Sum(c => c.Current).GetValueOrDefault()

                };
            }
        }
        public CollectionCess TotalCollectionCessAfterTah
        {
            get
            {
                return new CollectionCess
                {
                    MoreThanThree = TotalCollectionCessAfterMovement.MoreThanThree + TahCollectionCess.MoreThanThree.GetValueOrDefault(),
                    Third = TotalCollectionCessAfterMovement.Third + TahCollectionCess.Third.GetValueOrDefault(),
                    Second = TotalCollectionCessAfterMovement.Second + TahCollectionCess.Second.GetValueOrDefault(),
                    Previous = TotalCollectionCessAfterMovement.Previous + TahCollectionCess.Previous.GetValueOrDefault(),
                    Current = TotalCollectionCessAfterMovement.Current + TahCollectionCess.Current.GetValueOrDefault(),

                };
            }
        }
        public CollectionWaterTax TotalCollectionWaterTaxAfterTah
        {
            get
            {
                return new CollectionWaterTax
                {
                    MoreThanThree = TotalCollectionWaterTaxAfterMovement.MoreThanThree + TahCollectionWaterTax.MoreThanThree.GetValueOrDefault(),
                    Third = TotalCollectionWaterTaxAfterMovement.Third + TahCollectionWaterTax.Third.GetValueOrDefault(),
                    Second = TotalCollectionWaterTaxAfterMovement.Second + TahCollectionWaterTax.Second.GetValueOrDefault(),
                    Previous = TotalCollectionWaterTaxAfterMovement.Previous + TahCollectionWaterTax.Previous.GetValueOrDefault(),
                    Current = TotalCollectionWaterTaxAfterMovement.Current + TahCollectionWaterTax.Current.GetValueOrDefault(),

                };
            }
        }
        public CollectionLandRevenue TotalCollectionLandRevenueAfterTah
        {
            get
            {
                return new CollectionLandRevenue
                {
                    MoreThanThree = TotalCollectionLandRevenueAfterMovement.MoreThanThree + TahCollectionLanadRevenue.MoreThanThree.GetValueOrDefault(),
                    Third = TotalCollectionLandRevenueAfterMovement.Third + TahCollectionLanadRevenue.Third.GetValueOrDefault(),
                    Second = TotalCollectionLandRevenueAfterMovement.Second + TahCollectionLanadRevenue.Second.GetValueOrDefault(),
                    Previous = TotalCollectionLandRevenueAfterMovement.Previous + TahCollectionLanadRevenue.Previous.GetValueOrDefault(),
                    Current = TotalCollectionLandRevenueAfterMovement.Current + TahCollectionLanadRevenue.Current.GetValueOrDefault(),

                };
            }
        }
        
        public CollectionWaterTax TotalCollectionWaterTaxAfterMovement
        {
            get
            {
                return TotalCollectionWaterTax;
            }
        }
        public CollectionLandRevenue TotalCollectionLandRevenueAfterMovement
        {
            get
            {
                return TotalCollectionLandRevenue;
            }
        }
        public CollectionCess TotalCollectionCessAfterMovement
        {
            get
            {
                return new CollectionCess
                {
                    MoreThanThree = Village.IFormDetailCesses.Sum(c => c.MoreThanThree).GetValueOrDefault() + ComeFromVillagesCess.Sum(m => m.MoreThanThree).GetValueOrDefault() - GoToVillagesCess.Sum(m => m.MoreThanThree).GetValueOrDefault(),
                    Third = Village.IFormDetailCesses.Sum(c => c.Third).GetValueOrDefault() + ComeFromVillagesCess.Sum(m => m.Third).GetValueOrDefault() - GoToVillagesCess.Sum(m => m.Third).GetValueOrDefault(),
                    Second = Village.IFormDetailCesses.Sum(c => c.Second).GetValueOrDefault() + ComeFromVillagesCess.Sum(m => m.Second).GetValueOrDefault() - GoToVillagesCess.Sum(m => m.Second).GetValueOrDefault(),
                    Previous = Village.IFormDetailCesses.Sum(c => c.Previous).GetValueOrDefault() + ComeFromVillagesCess.Sum(m => m.Previous).GetValueOrDefault() - GoToVillagesCess.Sum(m => m.Previous).GetValueOrDefault(),
                    Current = Village.IFormDetailCesses.Sum(c => c.Current).GetValueOrDefault() + ComeFromVillagesCess.Sum(m => m.Current).GetValueOrDefault() - GoToVillagesCess.Sum(m => m.Current).GetValueOrDefault(),

                };
            }
        }
      
        public CollectionCess NetCollectionCess
        {
            get
            {
                return new CollectionCess
                {
                    MoreThanThree = TotalCollectionCessAfterTah.MoreThanThree - AdvanceCollectionCess.MoreThanThree.GetValueOrDefault(),
                    Third = TotalCollectionCessAfterTah.Third - AdvanceCollectionCess.Third.GetValueOrDefault(),
                    Second = TotalCollectionCessAfterTah.Second - AdvanceCollectionCess.Second.GetValueOrDefault(),
                    Previous = TotalCollectionCessAfterTah.Previous - AdvanceCollectionCess.Previous.GetValueOrDefault(),
                    Current = TotalCollectionCessAfterTah.Current - AdvanceCollectionCess.Current.GetValueOrDefault(),
                    Advance=AdvanceCollectionCess.Total

                };
            }
        }
        public CollectionLandRevenue NetCollectionLandRevenue
        {
            get
            {
                return new CollectionLandRevenue
                {
                    MoreThanThree = TotalCollectionLandRevenueAfterTah.MoreThanThree-AdvanceCollectionLandRevenue.MoreThanThree.GetValueOrDefault() ,
                    Third = TotalCollectionLandRevenueAfterTah.Third - AdvanceCollectionLandRevenue.Third.GetValueOrDefault(),
                    Second = TotalCollectionLandRevenueAfterTah.Second - AdvanceCollectionLandRevenue.Second.GetValueOrDefault(),
                    Previous = TotalCollectionLandRevenueAfterTah.Previous - AdvanceCollectionLandRevenue.Previous.GetValueOrDefault(),
                    Current = TotalCollectionLandRevenueAfterTah.Current - AdvanceCollectionLandRevenue.Current.GetValueOrDefault(),
                    Advance=AdvanceCollectionLandRevenue.Total

                };
            }
        }
        public CollectionWaterTax NetCollectionWaterTax
        {
            get
            {
                return new CollectionWaterTax
                {
                    MoreThanThree = TotalCollectionWaterTaxAfterTah.MoreThanThree - AdvanceCollectionWaterTax.MoreThanThree.GetValueOrDefault(),
                    Third = TotalCollectionWaterTaxAfterTah.Third - AdvanceCollectionWaterTax.Third.GetValueOrDefault(),
                    Second = TotalCollectionWaterTaxAfterTah.Second - AdvanceCollectionWaterTax.Second.GetValueOrDefault(),
                    Previous = TotalCollectionWaterTaxAfterTah.Previous - AdvanceCollectionWaterTax.Previous.GetValueOrDefault(),
                    Current = TotalCollectionWaterTaxAfterTah.Current - AdvanceCollectionWaterTax.Current.GetValueOrDefault(),
                    Advance=AdvanceCollectionWaterTax.Total

                };
            }
        }
        public AdvanceCollectionCess AdvanceCollectionCess
        {
            get
            {
                return new AdvanceCollectionCess {
                    MoreThanThree=Village.AdvanceCollectionCesses.Sum(a=>a.MoreThanThree),
                    Third = Village.AdvanceCollectionCesses.Sum(a => a.Third),
                    Second = Village.AdvanceCollectionCesses.Sum(a => a.Second),
                    Previous = Village.AdvanceCollectionCesses.Sum(a => a.Previous),
                    Current = Village.AdvanceCollectionCesses.Sum(a => a.Current),
                };
            }
        }
        public AdvanceCollectionWaterTax AdvanceCollectionWaterTax
        {
            get
            {
                return new AdvanceCollectionWaterTax
                {
                    MoreThanThree = Village.AdvanceCollectionWaterTaxes.Sum(a => a.MoreThanThree),
                    Third = Village.AdvanceCollectionWaterTaxes.Sum(a => a.Third),
                    Second = Village.AdvanceCollectionWaterTaxes.Sum(a => a.Second),
                    Previous = Village.AdvanceCollectionWaterTaxes.Sum(a => a.Previous),
                    Current = Village.AdvanceCollectionWaterTaxes.Sum(a => a.Current),
                };
            }
        }

        public AdvanceCollectionLandRevenue AdvanceCollectionLandRevenue        {
            get
            {
                return new AdvanceCollectionLandRevenue
                {
                    MoreThanThree = Village.AdvanceCollectionLandRevenues.Sum(a => a.MoreThanThree),
                    Third = Village.AdvanceCollectionLandRevenues.Sum(a => a.Third),
                    Second = Village.AdvanceCollectionLandRevenues.Sum(a => a.Second),
                    Previous = Village.AdvanceCollectionLandRevenues.Sum(a => a.Previous),
                    Current = Village.AdvanceCollectionLandRevenues.Sum(a => a.Current),
                };
            }
        }
        public BalanceCess BalanceCess
        {
            get
            {
                return new BalanceCess(NetCollectionCess, AdvanceCollectionCess, NetDemandCess);
            }
        }
        public BalanceWaterTax BalanceWaterTax
        {
            get
            {
                return new BalanceWaterTax(NetCollectionWaterTax,AdvanceCollectionWaterTax, NetDemandWaterTax);
            }
        }
        public BalanceLandRevenue BalanceLandRevenue
        {
            get
            {
                return new BalanceLandRevenue(NetCollectionLandRevenue, AdvanceCollectionLandRevenue, NetDemandLandRevenue);
            }
        }


        public DemandPartOneRev DemandPartOneRev
        {
            get
            {
                return new DemandPartOneRev
                {
                    MoreThanThree = DemandCess.MoreThanThree + DemandLandRevenue.MoreThanThree + DemandWaterTax.MoreThanThree,
                    Third = DemandCess.Third + DemandLandRevenue.Third + DemandWaterTax.Third,
                    Second = DemandCess.Second + DemandLandRevenue.Second + DemandWaterTax.Second,
                    Previous = DemandCess.Previous + DemandLandRevenue.Previous + DemandWaterTax.Previous,
                    Current = DemandCess.Current + DemandLandRevenue.Current + DemandWaterTax.Current,
                    Advance = DemandCess.Advance + DemandLandRevenue.Advance + DemandWaterTax.Advance,
                    Increase = DemandCess.Increase + DemandLandRevenue.Increase
                };
            }
        }
        public PartOneRev CollectionPartOneRev
        {
            get
            {
                return new PartOneRev
                {
                    MoreThanThree = NetCollectionCess.MoreThanThree + NetCollectionLandRevenue.MoreThanThree + NetCollectionWaterTax.MoreThanThree,
                    Third = NetCollectionCess.Third + NetCollectionLandRevenue.Third + NetCollectionWaterTax.Third,
                    Second = NetCollectionCess.Second + NetCollectionLandRevenue.Second + NetCollectionWaterTax.Second,
                    Previous = NetCollectionCess.Previous + NetCollectionLandRevenue.Previous + NetCollectionWaterTax.Previous,
                    Current = NetCollectionCess.Current + NetCollectionLandRevenue.Current + NetCollectionWaterTax.Current,
                    Advance = NetCollectionCess.Advance + NetCollectionLandRevenue.Advance + NetCollectionWaterTax.Advance

                };
            }
        }
        public PartOneRev BalancePartOneRev
        {
            get
            {
                return new PartOneRev
                {
                    MoreThanThree = BalanceCess.MoreThanThree + BalanceLandRevenue.MoreThanThree + BalanceWaterTax.MoreThanThree,
                    Third = BalanceCess.Third + BalanceLandRevenue.Third + BalanceWaterTax.Third,
                    Second = BalanceCess.Second + BalanceLandRevenue.Second + BalanceWaterTax.Second,
                    Previous = BalanceCess.Previous + BalanceLandRevenue.Previous + BalanceWaterTax.Previous,
                    Current = BalanceCess.Current + BalanceLandRevenue.Current + BalanceWaterTax.Current,
                    Advance = BalanceCess.Advance + BalanceLandRevenue.Advance + BalanceWaterTax.Advance

                };
            }
        }
    }

}

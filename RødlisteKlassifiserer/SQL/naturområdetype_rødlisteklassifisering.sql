create view _naturområdetype_rødlisteklassifisering as

-- All rødlisteklassifisering only on main type
select 
nt.id as naturområdetype_id,
rk.id as rødlisteklassifisering_id
from
NaturområdeTypeKodeSet nt,
RødlisteKlassifiseringSet rk
where
nt.Id = rk.NaturområdeTypeKode_Id

union all

-- All rødlistekalssifisering not on main type
select 
nt.id as naturområdetype_id,
rk.id as rødlisteklassifisering_id
from
NaturområdeTypeKodeSet nt,
KartleggingsKodeSet kk,
RødlisteKlassifiseringSet rk,
KartleggingsKodeRødlisteKlassifisering kk_rk
where
nt.Id = kk.NaturområdeTypeKode_Id
and
kk.Id = kk_rk.KartleggingsKode_Id
and
rk.Id = kk_rk.RødlisteKlassifisering_Id

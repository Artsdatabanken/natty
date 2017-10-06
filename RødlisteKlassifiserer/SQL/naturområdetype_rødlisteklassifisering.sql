create view _naturomr�detype_r�dlisteklassifisering as

-- All r�dlisteklassifisering only on main type
select 
nt.id as naturomr�detype_id,
rk.id as r�dlisteklassifisering_id
from
Naturomr�deTypeKodeSet nt,
R�dlisteKlassifiseringSet rk
where
nt.Id = rk.Naturomr�deTypeKode_Id

union all

-- All r�dlistekalssifisering not on main type
select 
nt.id as naturomr�detype_id,
rk.id as r�dlisteklassifisering_id
from
Naturomr�deTypeKodeSet nt,
KartleggingsKodeSet kk,
R�dlisteKlassifiseringSet rk,
KartleggingsKodeR�dlisteKlassifisering kk_rk
where
nt.Id = kk.Naturomr�deTypeKode_Id
and
kk.Id = kk_rk.KartleggingsKode_Id
and
rk.Id = kk_rk.R�dlisteKlassifisering_Id

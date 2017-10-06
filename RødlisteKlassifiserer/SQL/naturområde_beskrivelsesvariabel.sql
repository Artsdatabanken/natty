create view _naturomr�de_beskrivelsesvariabel as

-- All naturomr�de with beskrivelsesvariablel
select 
n.id as naturomr�de_id,
nt.id as naturomr�detype_id,
bv.id as beskrivelsesvariabel_id,
nt.kode as naturomr�detype_kode,
bv.kode as beskrivelsesvariabel_kode
 from 
Naturomr�deType nt,
Naturomr�de n,
Beskrivelsesvariabel bv
where
nt.naturomr�de_id = n.id
and
bv.naturomr�de_id = n.id
and
bv.naturomr�detype_id = nt.id

union all

-- All naturomr�de without beskrivelsesvariabel
select 
n.id as naturomr�de_id,
nt.id as naturomr�detype_id,
null as beskrivelsesvariabel_id,
nt.kode as naturomr�detype_kode,
null as beskrivelsesvariabel_kode
 from 
Naturomr�deType nt,
Naturomr�de n
where
nt.naturomr�de_id = n.id
and
nt.id not in (select bv.naturomr�detype_id from Beskrivelsesvariabel bv)
and
n.id not in (select bv.naturomr�de_id from Beskrivelsesvariabel bv)
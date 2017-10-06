create view _naturområde_beskrivelsesvariabel as

-- All naturområde with beskrivelsesvariablel
select 
n.id as naturområde_id,
nt.id as naturområdetype_id,
bv.id as beskrivelsesvariabel_id,
nt.kode as naturområdetype_kode,
bv.kode as beskrivelsesvariabel_kode
 from 
NaturområdeType nt,
Naturområde n,
Beskrivelsesvariabel bv
where
nt.naturområde_id = n.id
and
bv.naturområde_id = n.id
and
bv.naturområdetype_id = nt.id

union all

-- All naturområde without beskrivelsesvariabel
select 
n.id as naturområde_id,
nt.id as naturområdetype_id,
null as beskrivelsesvariabel_id,
nt.kode as naturområdetype_kode,
null as beskrivelsesvariabel_kode
 from 
NaturområdeType nt,
Naturområde n
where
nt.naturområde_id = n.id
and
nt.id not in (select bv.naturområdetype_id from Beskrivelsesvariabel bv)
and
n.id not in (select bv.naturområde_id from Beskrivelsesvariabel bv)
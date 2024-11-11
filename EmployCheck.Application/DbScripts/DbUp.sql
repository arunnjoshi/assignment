Delete
from Employment;

insert into Employment(CompanyName, VerificationCode, IsEmploymentVerified, CreatedOn, VerifiedOn)
values ('MicroSoft', '1234', 0, DATE('now'), null),
       ('Google', '4321', 0, DATE('now'), null),
       ('Amazon', '7860', 0, DATE('now'), null),
       ('Facebook', '9898', 0, DATE('now'), null),
       ('Tesla', '1212', 0, DATE('now'), null),
       ('Zoho', '0001', 0, DATE('now'), null),
       ('Kellton', '1142', 1, DATE('now'), null),
       ('OneBcg', '6162', 1, DATE('now'), null);

select *
from Employment;
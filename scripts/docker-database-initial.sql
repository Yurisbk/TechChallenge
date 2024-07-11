create table contacts(
    id serial primary key,
    fullname varchar,
    ddi varchar,
    ddd varchar,
    phonenumber varchar,
    email varchar,
    region varchar
);

create table region(
    id serial primary key,
    ddd varchar,
    region varchar
);

create table users(
    id serial primary key,
    username varchar,
    passwordvalue varchar,
    roletype varchar
);

INSERT INTO contacts (fullname, ddi, ddd, phonenumber, email) VALUES
('John Doe', '1', '202', '5551234', 'john.doe@example.com'),
('Jane Smith', '44', '20', '79461234', 'jane.smith@example.co.uk'),
('Carlos Souza', '55', '11', '99887766', 'carlos.souza@example.com.br'),
('Marie Curie', '33', '1', '2345678', 'marie.curie@example.fr'),
('Yuki Tanaka', '81', '3', '12345678', 'yuki.tanaka@example.jp'),
('Liam O Connor', '353', '1', '87654321', 'liam.oconnor@example.ie'),
('Ayesha Khan', '91', '22', '12345678', 'ayesha.khan@example.in'),
('Hans Müller', '49', '30', '98765432', 'hans.muller@example.de'),
('Chen Wei', '86', '10', '87654321', 'chen.wei@example.cn'),
('Fatima Al-Farsi', '971', '4', '43218765', 'fatima.alfarsi@example.ae');

INSERT INTO users(username, passwordvalue, roletype) VALUES
    ('Admin', '1234', 'admin'),
    ('NotAdmin', '4321', 'employer');

INSERT INTO region(ddd, region) VALUES
    (11, 'São Paulo'),
    (12, 'São Paulo'),
    (13, 'São Paulo'),
    (14, 'São Paulo'),
    (15, 'São Paulo'),
    (16, 'São Paulo'),
    (17, 'São Paulo'),
    (18, 'São Paulo'),
    (19, 'São Paulo'),
    (21, 'Rio de Janeiro'),
    (22, 'Rio de Janeiro'),
    (24, 'Rio de Janeiro'),
    (27, 'Espírito Santo'),
    (28, 'Espírito Santo'),
    (31, 'Minas Gerais'),
    (32, 'Minas Gerais'),
    (33, 'Minas Gerais'),
    (34, 'Minas Gerais'),
    (35, 'Minas Gerais'),
    (37, 'Minas Gerais'),
    (38, 'Minas Gerais'),
    (41, 'Paraná'),
    (42, 'Paraná'),
    (43, 'Paraná'),
    (44, 'Paraná'),
    (45, 'Paraná'),
    (46, 'Paraná'),
    (47, 'Santa Catarina'),
    (48, 'Santa Catarina'),
    (49, 'Santa Catarina'),
    (51, 'Rio Grande do Sul'),
    (53, 'Rio Grande do Sul'),
    (54, 'Rio Grande do Sul'),
    (55, 'Rio Grande do Sul'),
    (61, 'Distrito Federal'),
    (62, 'Goiás'),
    (63, 'Tocantins'),
    (64, 'Goiás'),
    (65, 'Mato Grosso'),
    (66, 'Mato Grosso'),
    (67, 'Mato Grosso do Sul'),
    (68, 'Acre'),
    (69, 'Rondônia'),
    (71, 'Bahia'),
    (73, 'Bahia'),
    (74, 'Bahia'),
    (75, 'Bahia'),
    (77, 'Bahia'),
    (79, 'Sergipe'),
    (81, 'Pernambuco'),
    (82, 'Alagoas'),
    (83, 'Paraíba'),
    (84, 'Rio Grande do Norte'),
    (85, 'Ceará'),
    (86, 'Piauí'),
    (87, 'Pernambuco'),
    (88, 'Ceará'),
    (89, 'Piauí'),
    (91, 'Pará'),
    (92, 'Amazonas'),
    (93, 'Pará'),
    (94, 'Pará'),
    (95, 'Roraima'),
    (96, 'Amapá'),
    (97, 'Amazonas'),
    (98, 'Maranhão'),
    (99, 'Maranhão');

CREATE VIEW contacts_region_view AS
SELECT c.id, c.fullname, c.ddi, c.ddd, c.phonenumber, c.email, r.region
FROM contacts c
INNER JOIN region r ON c.ddd = r.ddd;
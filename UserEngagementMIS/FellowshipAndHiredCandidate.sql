
Use [UserEngagementDB]
Go
CREATE TABLE tblHired_candidates (
  id int NOT NULL,
  first_name varchar(100) NOT NULL,
  middle_name varchar(100) DEFAULT NULL,
  last_name varchar(100) NOT NULL,
  email varchar(50) NOT NULL,
  mobile_num bigint NOT NULL,
  hired_city varchar(50) NOT NULL,
  hired_date datetime NOT NULL,
  degree varchar(100) NOT NULL,
  aggr_per float NULL,
  current_pincode int DEFAULT NULL,
  permanent_pincode int DEFAULT NULL,
  hired_lab varchar(20) DEFAULT NULL,
  attitude_remark varchar(15) DEFAULT NULL,
  communication_remark varchar(15) DEFAULT NULL,
  knowledge_remark varchar(15) DEFAULT NULL,
  status varchar(20) NOT NULL,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
  PRIMARY KEY (id)
);

select * from tblHired_candidates;


CREATE TABLE fellowship_candidates (
  id int NOT NULL,
  first_name varchar(100) NOT NULL,
  middle_name varchar(100) DEFAULT NULL,
  last_name varchar(100) NOT NULL,
  email varchar(50) NOT NULL,
  mobile_num bigint NOT NULL,
  hired_city varchar(50) NOT NULL,
  hired_date datetime NOT NULL,
  degree varchar(50) NOT NULL,
  aggr_per float  NULL,
  current_pincode int DEFAULT NULL,
  permanent_pincode int DEFAULT NULL,
  hired_lab varchar(20) DEFAULT NULL,
  attitude_remark varchar(15) DEFAULT NULL,
  communication_remark varchar(15) DEFAULT NULL,
  knowledge_remark varchar(15) DEFAULT NULL,
  birth_date date NOT NULL,
  is_birth_date_verified int  DEFAULT 0,
  parent_name varchar(50) DEFAULT NULL,
  parent_occupation varchar(100) NOT NULL,
  parent_mobile_num bigint NOT NULL,
  parent_annual_sal float  NULL,
  local_addr varchar(255) NOT NULL,
  permanent_addr varchar(150) DEFAULT NULL,
  photo_path varchar(500) DEFAULT NULL,
  joining_date date DEFAULT NULL,
  candidate_status varchar(20) NOT NULL,
  personal_info_filled int  DEFAULT 0,
  bank_info_filled int  DEFAULT 0,
  educational_info_filled int  DEFAULT 0,
  doc_status varchar(20) DEFAULT NULL,
  remark varchar(150) DEFAULT NULL,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
  PRIMARY KEY (id)
);

select * from fellowship_candidates;

insert into fellowship_candidates values(1, 'deepak', 'Kiran', 'Patil', 'deepak.63584@gmail.com ', 8956748596, 'Pune','2019-12-13','B.E', 75.25,5245,5478,'Mumbai', 'Good', 'Good', 'Good', '1999-12-13', 1, 'Kiran', 'Farmer', 7584962547, 300000, 'Pune', 'Pune', 'photo_path', '2019-12-13', 'Good', 1, 1, 1, 'Correct', 'Good', null, 1);

CREATE TABLE tblCandidates_personal_det_check (
  id int NOT NULL,
  candidate_id  int NOT NULL,
  field_name int NOT NULL,
  is_verified int  DEFAULT NULL,
  lastupd_stamp datetime DEFAULT NULL,
  lastupd_user int DEFAULT NULL,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL
);

select * from tblCandidates_personal_det_check;

CREATE TABLE tblCandidate_bank_det(
  id int NOT NULL,
  candidate_id int NOT NULL,
  name varchar(100) NOT NULL,
  account_num int NOT NULL,
  is_account_num_verified int  DEFAULT 0,
  ifsc_code varchar(20) NOT NULL,
  is_ifsc_code_verified int DEFAULT 0,
  pan_number varchar(10) DEFAULT NULL,
  is_pan_number_verified int  DEFAULT 0,
  addhaar_num int NOT NULL,
  is_addhaar_num_verified int DEFAULT 0,
  PRIMARY KEY (id),
  CONSTRAINT FK_candidate_id_Fellowship_Id FOREIGN KEY (candidate_id) REFERENCES fellowship_candidates (id),
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
);

select * from tblCandidate_bank_det;

CREATE TABLE tblCandidates_bank_det_check (
  id int NOT NULL,
  candidate_id  int  NOT NULL,
  field_name int NOT NULL,
  is_verified int  DEFAULT NULL,
  lastupd_stamp datetime DEFAULT NULL,
  lastupd_user int DEFAULT NULL,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL
);

Select * from tblCandidates_bank_det_check;

CREATE TABLE tblcandidate_qualification(
  id int NOT NULL,
  candidate_id int NOT NULL,
  diploma int  DEFAULT 0,
  degree_name varchar(10) NOT NULL,
  is_degree_name_verified int  DEFAULT 0,
  employee_decipline varchar(100) NOT NULL,
  is_employee_decipline_verified int DEFAULT 0,
  passing_year int NOT NULL,
  is_passing_year_verified int  DEFAULT 0,
  aggr_per float DEFAULT NULL,
  final_year_per float DEFAULT NULL,
  is_final_year_per_verified int DEFAULT 0,
  training_institute varchar(20) NOT NULL,
  is_training_institute_verified int DEFAULT 0,
  training_duration_month int DEFAULT NULL,
  is_training_duration_month_verified int DEFAULT 0,
  other_training varchar(255) DEFAULT NULL,
  is_other_training_verified int DEFAULT 0,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
  CONSTRAINT FK_candidates_id_fellowship_ID FOREIGN KEY (candidate_id) REFERENCES fellowship_candidates (id),
  PRIMARY KEY (id)
);
 select * from tblcandidate_qualification;

 CREATE TABLE tblCandidates_education_det_check (
  id int NOT NULL,
  candidate_id  int  NOT NULL,
  field_name int NOT NULL,
  is_verified int  DEFAULT NULL,
  lastupd_stamp datetime DEFAULT NULL,
  lastupd_user int DEFAULT NULL,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL
);

select * from tblCandidates_education_det_check;



CREATE TABLE tblCandidate_docs(
  id int NOT NULL,
  candidate_id int NOT NULL,
  doc_type varchar(20) DEFAULT NULL,
  doc_path varchar(500) DEFAULT NULL,
  status int DEFAULT 1,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
  CONSTRAINT FK_candidate_docs_candidate_id FOREIGN KEY (candidate_id) REFERENCES fellowship_candidates (id),
  PRIMARY KEY (id)
);

select * from tblCandidate_docs;

CREATE TABLE tblUser_details (
  id int NOT NULL,
  email varchar(50) NOT NULL,
  first_name varchar(100) NOT NULL,
  last_name varchar(100) NOT NULL,
  password varchar(15) NOT NULL,
  contact_number bigint NOT NULL,
  verified bit DEFAULT NULL,
  PRIMARY KEY (id),
  CONSTRAINT UK_Email_id Unique(email)
);

select * from tblUser_details;

CREATE TABLE tblUser_roles (
  user_id int NOT NULL ,
  role_name varchar(100)
);

select * from tblUser_roles;

CREATE TABLE tblCompany(
  id int NOT NULL,
  name int NOT NULL,
  address varchar(150) DEFAULT NULL,
  location varchar(50) DEFAULT NULL,
  status int DEFAULT 1,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
  PRIMARY KEY (id)
);

select * from tblCompany;

CREATE TABLE tblTech_type (
  id int NOT NULL,
  type_name varchar(50) NOT NULL,
  cur_status char(1) DEFAULT NULL,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
  Primary Key(id)
);

select * from tblTech_type;

CREATE TABLE tblTech_stack(
  id int NOT NULL,
  stack_name varchar(50) NOT NULL,
  cur_status char(1) DEFAULT NULL,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
  Primary Key(id)
);

Alter table tblTech_stack
Add image_path varchar(500) Default Null;

Alter table tblTech_stack
Add framework Text Default Null;

Exec sp_rename 'tblTech_stack.stack_name','tech_name','column';

select * from tblTech_stack;

CREATE TABLE tblMaker_program(
  id int NOT NULL,
  program_name int NOT NULL,
  program_type varchar(10) DEFAULT NULL,
  program_link text DEFAULT NULL,
  tech_stack_id int DEFAULT NULL,
  tech_type_id int NOT NULL,
  is_program_approved int,
  description varchar(500) DEFAULT NULL,
  status int DEFAULT 1,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
  CONSTRAINT FK_maker_program_tech_stack_id FOREIGN KEY (tech_stack_id) REFERENCES tblTech_stack (id),
  CONSTRAINT FK_maker_program_tech_type_id FOREIGN KEY (tech_type_id) REFERENCES tblTech_type (id),
  PRIMARY KEY (id)
);

select * from tblMaker_program;

CREATE TABLE tblLab(
  id int NOT NULL,
  name varchar(50) DEFAULT NULL,
  location varchar(50) DEFAULT NULL,
  address  varchar(255) DEFAULT NULL,
  status int DEFAULT 1,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
  PRIMARY KEY (id)
);

select * from tblLab;

CREATE TABLE tblApp_parameters (
  id int NOT NULL,
  key_type varchar(20) NOT NULL,
  key_value varchar(20) NOT NULL,
  key_text varchar(80) DEFAULT NULL,
  cur_status char(1) DEFAULT NULL,
  lastupd_user int DEFAULT NULL,
  lastupd_stamp datetime DEFAULT NULL,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
  seq_num int DEFAULT NULL,
);

select * from tblApp_parameters;

CREATE TABLE tblMentor(
  id int NOT NULL,
  name varchar(50) DEFAULT NULL,
  mentor_type varchar(20) DEFAULT NULL,
  lab_id int NOT NULL,
  status int DEFAULT 1,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
  CONSTRAINT FK_mentor_lab_id FOREIGN KEY (lab_id) REFERENCES tblMentor (id),
  PRIMARY KEY (id)
);

select * from tblMentor;

CREATE TABLE tblMentor_ideation_map(
  id int NOT NULL,
  mentor_id int NOT NULL,
  status int DEFAULT 1,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
  CONSTRAINT FK_mentor_ideation_map_mentor_id FOREIGN KEY (mentor_id) REFERENCES tblMentor (id),
  PRIMARY KEY (id)
);

select * from tblMentor_ideation_map;

CREATE TABLE tblMentor_techstack(
  id int NOT NULL,
  mentor_id int NOT NULL,
  tech_stack_id int NOT NULL,
  status int DEFAULT 1,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
  PRIMARY KEY (id),
  CONSTRAINT FK_mentor_mentor_id FOREIGN KEY (mentor_id) REFERENCES tblMentor (id),
  CONSTRAINT FK_mentor_tech_stack_id FOREIGN KEY (tech_stack_id) REFERENCES tblTech_stack (id)
);

select * from tblMentor_techstack;

CREATE TABLE tblLab_threshold(
  id int NOT NULL,
  lab_id int NOT NULL,
  lab_capacity varchar(50) DEFAULT NULL,
  lead_threshold int DEFAULT NULL,
  ideation_engg_threshold int DEFAULT NULL,
  buddy_engg_threshold int DEFAULT NULL,
  status int DEFAULT 1,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
  PRIMARY KEY (id),
);

CREATE TABLE tblCompany_requirement(
id int NOT NULL,
company_id int NOT NULL,
candidate_id int NOT NULL,
requested_month varchar(20) NOT NULL,
city varchar(20) DEFAULT NULL,
is_doc_verification int DEFAULT 1,
requirement_doc_path varchar(500) DEFAULT NULL,
no_of_engg int NOT NULL,
tech_stack_id int NOT NULL,
tech_type_id int NOT NULL,
maker_programs_id int NOT NULL,
lead_id int NOT NULL,
ideateion_engg_id int DEFAULT NULL,
buddy_engg_id int  DEFAULT NULL,
special_remark text DEFAULT NULL,
status int DEFAULT 1,
creator_stamp datetime DEFAULT NULL,
creator_user int DEFAULT NULL,
 CONSTRAINT FK_candidate_candidate_id FOREIGN KEY (candidate_id) REFERENCES fellowship_candidates (id),
PRIMARY KEY(id)
);

CREATE TABLE tblCandidate_techstack_assignment(
  id int NOT NULL,
  requirement_id int NOT NULL,
  candidate_id int NOT NULL,
  assign_date datetime DEFAULT NULL,
  status varchar(20) DEFAULT NULL,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
  CONSTRAINT FK_candidate_techstack_assignment_requirement_id FOREIGN KEY (requirement_id) REFERENCES tblCompany_requirement (id),
  CONSTRAINT FK_candidate_candidates_id FOREIGN KEY (candidate_id) REFERENCES fellowship_candidates (id),
  PRIMARY KEY (id)
);

select * from tblCandidate_techstack_assignment














































































































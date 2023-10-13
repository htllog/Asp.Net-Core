if not exists (select * from information_schema.tables where table_schema = 'dbo' and table_name = 'ask_question_extend')
begin
create table dbo.ask_question_extend
(
    id int identity(1,1) primary key,
    title text not null,
    qid int not null
);
end;
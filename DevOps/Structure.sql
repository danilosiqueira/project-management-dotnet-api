create table if not exists projects (
    id serial not null primary key,
    title varchar(50) not null,
    description varchar(250) not null,
    begin_date timestamp not null,
    is_subproject boolean not null default false,
    parent_id integer
);

create table if not exists resource_types (
    id serial not null primary key,
    title varchar(50) not null
);

create table if not exists resources (
    id serial not null primary key,
    title varchar(50) not null,
    type integer not null references resource_types (id)
);

create table if not exists tasks (
    id serial not null primary key,
    title varchar(50) not null,
    description varchar(250) not null,
    created_date timestamp not null,
    due_date timestamp not null,
    is_done boolean not null default false,
    project_id integer not null references projects (id),
    assigned_to integer not null references resources (id)
);

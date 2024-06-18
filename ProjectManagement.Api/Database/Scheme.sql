create table if not exists users (
    id serial not null primary key,
    name varchar(50) not null,
    login varchar(12) not null,
    password varchar(100) not null,
    created_at timestamp not null default CURRENT_TIMESTAMP
);

create unique index if not exists uidx_users_login on users (login);

create table if not exists projects (
    id serial not null primary key,
    title varchar(50) not null,
    description varchar(250) not null,
    began_at timestamp not null,
    created_at timestamp not null default CURRENT_TIMESTAMP,
    is_subproject boolean not null default false,
    parent_id integer,
    user_id integer not null references users (id)
);

create index if not exists idx_projects_user_id on projects (user_id);

create table if not exists resource_types (
    id serial not null primary key,
    title varchar(50) not null
);

insert into resource_types (title) values
('Developer'),
('Designer');

create table if not exists resources (
    id serial not null primary key,
    title varchar(50) not null,
    type_id integer not null references resource_types (id)
);

create table if not exists tasks (
    id serial not null primary key,
    title varchar(50) not null,
    description varchar(250) not null,
    created_at timestamp not null default CURRENT_TIMESTAMP,
    began_at timestamp not null,
    done_at timestamp not null,
    due_date timestamp not null,
    is_done boolean not null default false,
    project_id integer not null references projects (id),
    assigned_to integer not null references resources (id),
    user_id integer not null references users (id)
);

create index if not exists idx_tasks_project_id on tasks (project_id);
create index if not exists idx_tasks_assigned_to on tasks (assigned_to);
create index if not exists idx_tasks_user_id on tasks (user_id);
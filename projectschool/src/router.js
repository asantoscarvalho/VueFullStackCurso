import Vue from 'vue';
import Router from 'vue-router';

import alunos from './components/Aluno/alunos.vue';
import professor from './components/Professor/professor.vue';
import Sobre from './components/_sobre/_sobre';
import alunodetalhe from './components/Aluno/alunodetalhe.vue';

Vue.use(Router);

export default new Router({
    routes:[
        {
            path: '/professores',
            nome: 'Professores',
            component: professor
        },
        {
            path: '/alunos/:prof_id',
            nome: 'Alunos',
            component: alunos
        },
        {
            path: '/alunosall',
            nome: 'Alunos',
            component: alunos
        },
        {
            path: '/alunodetalhe/:id',
            nome: 'AlunosDetalhe',
            component: alunodetalhe
        },
        {
            path: '/sobre',
            nome: 'Sobre',
            component: Sobre
        }
    ]
})
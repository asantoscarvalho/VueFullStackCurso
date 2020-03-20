<template>
    <div>
         <titulo texto="Professor" />
    <table border="1px">
      <thead>
        <th>Mat.</th>
        <th>Professor</th>
        <th>Qtd. Alunos</th>
      </thead>
      <tbody v-if="Professores.length">
        <tr v-for="(professor,index) in Professores" :key="index" >
          <td>{{professor.id}}</td>
          <router-link :to="`/alunos/${professor.id}`" tag="td" style="cursor: pointer">{{professor.nome}}  </router-link>
          <td>{{professor.QtdAlunos}}</td>
        </tr>
      </tbody>
      <tfoot v-if="!Professores.length">
        <tr>
          <td colspan="3" style="text-align: center;"><b>Nenhum professor cadastrado</b></td>
        </tr>
      </tfoot>
    </table>
    </div>
</template>

<script>
import titulo from '../_share/Titulo';
    export default {
         components: { titulo},
        data() {
            return {
                Professores:[],
                alunos:[]
            }
        },
        created(){
            this.$http
            .get('http://localhost:5000/api/alunos')
            .then(res => res.json())
            .then(alunos => {
              this.alunos = alunos;
              this.carregarProfessores();

              })
        },
        props: {
          
        },
        methods:{
          pegarQtdAlunosPorProfessor(){
            this.Professores.forEach((professor,index) => {
                  professor = {
                    id: professor.id,
                    nome: professor.nome,
                    QtdAlunos: this.alunos.filter(aluno => aluno.professorId == professor.id).length,
                    
                  }
                  this.Professores[index] = professor;
            });
          },
          carregarProfessores(){
            this.$http
            .get('http://localhost:5000/api/professores')
            .then(res => res.json())
            .then(professores => {
              this.Professores = professores
              this.pegarQtdAlunosPorProfessor();
              })
          }
        }
    }
</script>

<style lang="scss" scoped>

</style>
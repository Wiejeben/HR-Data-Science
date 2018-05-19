import * as React from 'react';
import styled from 'styled-components';
import Population from "./services/Population";
import DNA from "./services/DNA";

const Wrapper = styled.div`
    margin: 0 auto;
    max-width: 1000px;
    display: flex;
    flex-direction: row;
    justify-content: space-between
`;

const Title = styled.h1``;

const Column = styled.section``;

interface IAppState {
    bestPhrase: string;
    population: DNA[];
    averageFitness: number;
    totalGenerations: number;
    totalExecutionTime: number;
}

export default class App extends React.Component<any, IAppState> {
    protected targetPhrase: string = 'To be or not to be.';
    protected mutationRate: number = 0.01;
    protected maxPopulation: number = 200;
    protected population: Population;

    constructor(props: any) {
        super(props);
        this.evolve = this.evolve.bind(this);

        this.population = new Population(this.targetPhrase, this.mutationRate, this.maxPopulation);

        this.population.calcFitness();
        this.state = {
            ...this.getPopulationState(),
            totalExecutionTime: 0,
        };
    }

    public evolve(): void {
        const start = performance.now();
        this.population.naturalSelection();
        this.population.generate();
        this.population.calcFitness();
        const end = performance.now();

        this.setState({
            ...this.getPopulationState(),
            totalExecutionTime: this.state.totalExecutionTime + (end - start)
        });

        if (this.population.best().toString() !== this.targetPhrase) {
            window.requestAnimationFrame(this.evolve)
        }
    }

    public getPopulationState() {
        return {
            bestPhrase: this.population.best().toString(),
            population: this.population.getPopulation(),
            averageFitness: this.population.averageFitness(),
            totalGenerations: this.population.getGeneration(),
        };
    }

    public render() {
        return (
            <Wrapper>
                <Column>
                    <Title>Target phrase: {this.targetPhrase}</Title>
                    <Title>Best phrase: {this.state.bestPhrase}</Title>

                    <div>
                        total generations: {this.state.totalGenerations}<br/>
                        average fitness: {(this.state.averageFitness * 100).toFixed(2)}%<br/>
                        total population: {this.maxPopulation}<br/>
                        mutation rate: {this.mutationRate * 100}%<br/>
                        average execution time: { (this.state.totalGenerations > 0) ? (this.state.totalExecutionTime / this.state.totalGenerations).toFixed(2) : 0}ms<br/>
                        <button onClick={this.evolve}>Start evolving</button>
                    </div>
                </Column>
                <Column>
                    <ul>
                        {this.state.population.map((value, key) => <li key={key}>{value.toString()}</li>)}
                    </ul>
                </Column>
            </Wrapper>
        );
    }
}
